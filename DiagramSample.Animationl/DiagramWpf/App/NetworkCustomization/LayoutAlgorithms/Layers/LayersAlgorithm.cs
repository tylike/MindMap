using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using BusinessLogic;
using BusinessLogic.Data;
using DevExpress.Diagram.Core;
using DevExpress.Diagram.Core.Layout;
using DevExpress.Mvvm.Native;
using DevExpress.Xpf.Diagram;
using ProjectB.Views.WPF.Controls.NetworkDataFlow;
using ProjectB.Views.WPF.Controls.NetworkDataFlow.Data;
using ProjectB.Views.WPF.DataFlow_2_0.NetworkDisplayLayouts.Layout;
using ProjectB.Views.WPF.DataFlow_2_0.NetworkDisplayLayouts.Layout.Data;

namespace ProjectB.Views.WPF.DataFlow_2_0.NetworkDisplayLayouts.Layers
{
    /// <summary>
    /// Input for algorithm: the diagram nodes arranged by Sugiyama algorithm
    /// A top-bottom rows diagram traversal is done. For each node one of the following operations is possible:
    ///     - create a new layer within the current row if the node's layer hasn't been already added on the diagram traversal
    ///     - add the node to an existing layer, if the layer has been previously added (in the current row or in a previous one)
    ///     - postpone the node's arrangement if a layer with a higher order number has to be added later in traversal
    ///     - if certain nodes from the global postponed nodes list are found suitable, they are added in the current row layers
    /// The postponed nodes can be handled in two ways:
    ///     - adding certain postponed nodes to the newly added layers where they belong
    ///     - creating new layers for certain postponed nodes if there are no other nodes that had determined the creation of layers
    ///       (these postponed nodes are called isolated nodes because they can't be linked to any existing or to-be-added layer) 
    /// </summary>
    public class LayersAlgorithm
    {
        // the space above and below the nodes inside a layer
        public const int LayerPaddingUp = 5;
        public const int LayerPaddingDown = 22;
        public const int ExtraSpaceOnTranslating = 33;
        public const int MinimumHorizontalSpace = 15;

        private readonly NetworkData _networkData;
        private readonly DiagramControlEx _diagram;
        private readonly ENetworkDirection _direction;
        private readonly bool _extendLayersToTransformations;

        private List<NodeInfo> _allNodes;
        private List<LayerInfo> _allLayers;
        private List<List<NodeInfo>> _allNodesByRow;

        // nodes for which we don't immediately create a layer because layers with higher order number were detected in the
        // non-traversed DataFlow
        private List<NodeInfo> _postponedNodes;

        // layers in the DataFlow which were already discovered by DataFlow traversal
        private List<PositionedLayerInfo> _allEncounteredLayers;

        public LayersAlgorithm(NetworkData networkData, DiagramControlEx diagram, ENetworkDirection direction, bool extendLayersToTransformations)
        {
            _networkData = networkData;
            _diagram = diagram;
            _direction = direction;
            _extendLayersToTransformations = extendLayersToTransformations;
        }

        public void Apply()
        {
            GetNodes();
            _postponedNodes = new List<NodeInfo>();
            _allEncounteredLayers = new List<PositionedLayerInfo>();
            _networkData.NetworkLayers = ComputeNetworkLayers();
            AddContainersToDiagram();
        }

        #region nodes positioning algorithm

        private void ResolveMixture(int index, List<NodeInfo> notAllowedNodes)
        {
            // check the next row nodes, maybe the not allowed nodes fit there
            index++;

            var rowNodes = _allNodesByRow[index];
            var rowY = rowNodes.First().ManualYValue;

            if (rowNodes.All(x => !x.IsLayerAllowed))
            {
                foreach (var notAllowedNode in notAllowedNodes)
                {
                    SetXPositionInExistingRow(notAllowedNode, rowNodes);
                    notAllowedNode.ManualYValue = rowY;
                }
            }
            else
            {
                if (index < _allNodesByRow.Count - 1)
                {
                    ResolveMixture(index, notAllowedNodes);
                }
                else
                {
                    // just add them after the last row
                    var startingPosition = rowNodes.Max(x => x.Size.Height) + ExtraSpaceOnTranslating;
                    foreach (var notAllowedNode in notAllowedNodes)
                    {
                        notAllowedNode.ManualYValue = startingPosition;
                    }
                }
            }
        }

        private void HandleRow(int index)
        {
            var rowNodes = _allNodesByRow[index];

            var notAllowedNodes = rowNodes.Where(x => !x.IsLayerAllowed).ToList();

            if (notAllowedNodes.Any())
            {
                ResolveMixture(index, notAllowedNodes);
            }

            rowNodes = rowNodes.Except(notAllowedNodes).ToList();

            var rowLayersInfo = GetDistinctLayers(rowNodes.ToList());
            var rowYPosition = rowNodes.First().ManualYValue;
            var currentRowNewlyAddedLayers = new List<PositionedLayerInfo>();
            var currentRowPostponedNodes = new List<NodeInfo>();
            var initialRowBottomY = GetNodesIncludingTransformationsBottomY(rowNodes);

            var rowEntityNodes = rowNodes.Where(x => x.IsLayerAllowed).ToList();

            foreach (var node in rowEntityNodes.Where(x => ShouldPostponeNode(x, rowLayersInfo)))
            {
                PostponeNode(node, currentRowPostponedNodes);
            }

            foreach (var node in rowEntityNodes.Except(currentRowPostponedNodes))
            {
                // check if the node's layer was already added
                var alreadyEncounteredLayer = GetAlreadyEncounteredLayer(node.LayerInfo.Id);

                if (alreadyEncounteredLayer != null)
                {
                    var previousRowsEnlargement = AddNodeToExistingLayer(node, alreadyEncounteredLayer, currentRowNewlyAddedLayers.Contains(alreadyEncounteredLayer));
                    // keep track of the previous rows enlargements in order to use an updated start position of current row
                    initialRowBottomY += previousRowsEnlargement;
                    rowYPosition += previousRowsEnlargement;
                }
                else
                {
                    AddNodeToNewLayerWithinCurrentRow(rowNodes, rowLayersInfo, node, currentRowPostponedNodes,
                           rowYPosition, currentRowNewlyAddedLayers);
                }
            }

            var postponedNodesAddedInCurrentRow = AddPostponedNodesToCurrentRow(currentRowNewlyAddedLayers);

            var isTheLastRow = index == _allNodesByRow.Count - 1;
            HandleIsolatedPostponedNodes(currentRowNewlyAddedLayers, postponedNodesAddedInCurrentRow, isTheLastRow);

            var allHandledNodes = rowEntityNodes.Concat(postponedNodesAddedInCurrentRow).ToList();

            TranslateTheNodesBelow(initialRowBottomY, rowYPosition, currentRowNewlyAddedLayers, allHandledNodes);
        }

        private void AddNodeToNewLayerWithinCurrentRow(List<NodeInfo> rowNodes,
        List<LayerInfo> rowLayersInfo, NodeInfo node, List<NodeInfo> currentRowPostponedNodes,
        double rowYPosition, List<PositionedLayerInfo> currentRowEncounteredLayers)
        {
            // all the layers from the current row that are meant to stay on their current place
            // it means that we haven't ecountered yet those layers at an upper level

            var aboveRowLayers = new List<LayerInfo>();

            // the order number increases towards the root
            // Y value increases from above to the bottom

            // collect all the layers of the current row non-postponed nodes that should be above the current node's layer
            foreach (var layerInfo in rowLayersInfo.Where(x =>
                x.OrderNo > node.LayerInfo.OrderNo && currentRowPostponedNodes.All(y => y.LayerInfo.Id != x.Id)))
            {
                var encounteredLayer = _allEncounteredLayers.FirstOrDefault(x => x.LayerInfo.Id == layerInfo.Id);
                // if the layer was not yet added or it was added in a previous row 
                // => does not require any translation
                if (encounteredLayer == null || encounteredLayer.YPosition >= rowYPosition)
                {
                    aboveRowLayers.Add(layerInfo);
                }
            }

            double localTranslation = 0;

            foreach (var aboveRowLayer in aboveRowLayers)
            {
                localTranslation += GetNodesIncludingTransformationsMaxHeight(rowNodes.Where(x => x.LayerInfo.Id == aboveRowLayer.Id).ToList()) +
                                    ExtraSpaceOnTranslating;
            }

            node.ManualYValue += localTranslation;
            node.DependentTransformationNodes.ForEach(x => x.ManualYValue += localTranslation);

            var newLayer = new PositionedLayerInfo(node.LayerInfo);
            newLayer.Nodes.Add(node);
            newLayer.HeightIncludingTransformations = GetNodesIncludingTransformationsMaxHeight(new List<NodeInfo> { node });

            _allEncounteredLayers.Add(newLayer);
            currentRowEncounteredLayers.Add(newLayer);
        }

        private double AddNodeToExistingLayer(NodeInfo node, PositionedLayerInfo layer, bool areLayerAndNodeWithinTheSameRow)
        {
            // add the node to the existing layer
            var layerHeightBeforeAddingNode = layer.HeightIncludingTransformations;

            layer.HeightIncludingTransformations = Math.Max(layerHeightBeforeAddingNode, GetNodesIncludingTransformationsMaxHeight(new List<NodeInfo> { node }));

            var translation = node.ManualYValue - layer.YPosition;
            node.DependentTransformationNodes.ForEach(x => x.ManualYValue -= translation);
            node.ManualYValue = layer.YPosition;
            layer.Nodes.Add(node);

            var previousRowsEnlargement = 0.0;

            // if the existing layer is not part of the row where node is
            if (!areLayerAndNodeWithinTheSameRow)
            {
                // determine its suitable position on X axis in the existing layer
                SetXPositionInExistingLayer(node, layer);

                if (!layer.HeightIncludingTransformations.QuasiEqualTo(layerHeightBeforeAddingNode))
                {
                    // enlarge layer's height if necessary
                    previousRowsEnlargement = layer.HeightIncludingTransformations - layerHeightBeforeAddingNode;
                    var translationNodes = _allNodes.Where(x => x.ManualYValue > layer.YPosition && !node.DependentTransformationNodes.Contains(x));
                    translationNodes.ForEach(x => x.ManualYValue += previousRowsEnlargement);
                }
            }

            return previousRowsEnlargement;
        }

        private void TranslateTheNodesBelow(double initialRowBottomY, double rowYPosition, List<PositionedLayerInfo> currentRowEncounteredLayers,
            List<NodeInfo> allHandledNodes)
        {
            var allHandledNodesIncludingTransformations = allHandledNodes.Concat(allHandledNodes.SelectMany(x => x.DependentTransformationNodes)).ToList();

            var nodesToTranslate = _allNodes.
                Where(x => x.ManualYValue > rowYPosition && !allHandledNodesIncludingTransformations.Contains(x) && !IsPostponedNode(x)).ToList();

            if (currentRowEncounteredLayers.Count == 0)
            {
                // all the nodes were removed from the current row
                // translate up - there is an empty row caused by moving all its initial nodes to the corresponding layers
                var initialRowHeight = initialRowBottomY - rowYPosition;
                nodesToTranslate.ForEach(x => x.ManualYValue -= initialRowHeight + ExtraSpaceOnTranslating);
            }
            else
            {
                var finalRowBottomY = GetRowBottomYPosition(currentRowEncounteredLayers);
                var totalRowTranslation = finalRowBottomY - initialRowBottomY;

                if (!totalRowTranslation.QuasiEqualTo(0))
                {
                    nodesToTranslate.ForEach(x => x.ManualYValue += totalRowTranslation);
                }
            }
        }

        private PositionedLayerInfo GetAlreadyEncounteredLayer(Guid layerId)
        {
            return _allEncounteredLayers.FirstOrDefault(x => x.LayerInfo.Id == layerId &&
                                                             layerId != Constants.IdPredefinedLayerUnassigned);
        }

        private double GetRowBottomYPosition(List<PositionedLayerInfo> currentRowEncounteredLayers)
        {
            var maxYPositionForCurrentRow = currentRowEncounteredLayers.Max(x => x.YPosition + x.HeightIncludingTransformations);
            return maxYPositionForCurrentRow;
        }

        private List<LayerInfo> GetDistinctLayers(List<NodeInfo> nodes)
        {
            var layers = new List<LayerInfo>();
            var addedLayerIds = new List<Guid>();

            foreach (var node in nodes.Where(x => x.IsLayerAllowed))
            {
                if (!addedLayerIds.Contains(node.EntityNode.LayerInfo.Id))
                {
                    layers.Add(node.EntityNode.LayerInfo);
                    addedLayerIds.Add(node.EntityNode.LayerInfo.Id);
                }
            }

            return layers;
        }

        #region postponed nodes

        private bool ShouldAddIsolatedPostponedNodes(LayerInfo layerInfo, bool isTheLastRow)
        {
            bool shouldAddPostponedNodes;

            if (isTheLastRow)
            {
                // if we got to the last row in the data flow traversal, then this is the last chance to find a position
                // for the postponed nodes
                shouldAddPostponedNodes = true;
            }
            else
            {
                var notEncounteredYetLayers = _allLayers.Where(x => x.Id != layerInfo.Id &&
                                                                    !_allEncounteredLayers.Select(y => y.LayerInfo.Id).Contains(x.Id)).ToList();

                shouldAddPostponedNodes = notEncounteredYetLayers.Any() && notEncounteredYetLayers.Max(x => x.OrderNo) < layerInfo.OrderNo;
            }

            return shouldAddPostponedNodes;
        }

        /// <summary>
        /// It might be the case that the postponed nodes' layer does not exist in the remaining data flow traversal.
        /// It means we have to check if the right place to insert it is after the current row
        /// </summary>

        private void HandleIsolatedPostponedNodes(
            List<PositionedLayerInfo> currentRowEncounteredLayers, List<NodeInfo> postponedNodesAddedInCurrentRow, bool isTheLastRow)
        {
            var postponedNodesByLayers =
                _postponedNodes.OrderByDescending(x => x.LayerInfo.OrderNo).GroupBy(x => x.LayerInfo.Id);

            foreach (var postponedNodesByLayer in postponedNodesByLayers)
            {
                var layerInfo = postponedNodesByLayer.First().LayerInfo;

                if (ShouldAddIsolatedPostponedNodes(layerInfo, isTheLastRow))
                {
                    var newLayer = new PositionedLayerInfo(layerInfo)
                    {
                        HeightIncludingTransformations = GetNodesIncludingTransformationsMaxHeight(postponedNodesByLayer.ToList())
                    };

                    _allEncounteredLayers.Add(newLayer);
                    currentRowEncounteredLayers.Add(newLayer);

                    var yPosition = GetRowBottomYPosition(currentRowEncounteredLayers) + ExtraSpaceOnTranslating;

                    foreach (var postponedNode in postponedNodesByLayer.ToList())
                    {
                        var initialYPosition = postponedNode.ManualYValue;
                        postponedNode.ManualYValue = yPosition;
                        postponedNode.DependentTransformationNodes.ForEach(x => x.ManualYValue += postponedNode.ManualYValue - initialYPosition);

                        SetXPositionInExistingLayer(postponedNode, newLayer);
                        newLayer.Nodes.Add(postponedNode);

                        postponedNodesAddedInCurrentRow.Add(postponedNode);
                    }

                    foreach (var nodeInfo in postponedNodesByLayer.ToList())
                    {
                        _postponedNodes.Remove(nodeInfo);
                    }
                }
            }
        }


        private List<NodeInfo> AddPostponedNodesToCurrentRow(List<PositionedLayerInfo> currentRowNewlyAddedLayers)
        {
            var postponedNodesAddedInCurrentRow = new List<NodeInfo>();

            foreach (var currentRowLayer in currentRowNewlyAddedLayers)
            {
                // check if there are postponed nodes that fit in the layers added while handling the current row nodes
                var postponedNodesToBeAdded =
                    _postponedNodes.Where(x => x.LayerInfo.Id == currentRowLayer.LayerInfo.Id).ToList();

                foreach (var postponedNode in postponedNodesToBeAdded.ToList())
                {
                    AddNodeToExistingLayer(postponedNode, currentRowLayer, false);
                    _postponedNodes.Remove(postponedNode);
                    postponedNodesAddedInCurrentRow.Add(postponedNode);
                }
            }

            return postponedNodesAddedInCurrentRow;
        }

        private void PostponeNode(NodeInfo node, List<NodeInfo> currentRowPostponedNodes)
        {
            _postponedNodes.Add(node);
            currentRowPostponedNodes.Add(node);
        }

        private bool IsPostponedNode(NodeInfo node)
        {
            return _postponedNodes.Contains(node) ||
                   _postponedNodes.SelectMany(x => x.DependentTransformationNodes).Contains(node);
        }

        private bool ShouldPostponeNode(NodeInfo node, List<LayerInfo> rowLayersInfo)
        {
            if (node.LayerInfo.Id == Constants.IdPredefinedLayerUnassigned)
            {
                return false;
            }

            // layers that are upper than the current row layers, but they haven't been yet added 
            var layersThatCauseThePostpone = _allLayers.Where(x => x.OrderNo > node.LayerInfo.OrderNo &&
                                                                   rowLayersInfo.All(y => y.Id != x.Id) &&
                                                                   _allEncounteredLayers.All(y => y.LayerInfo.Id != x.Id));
            return layersThatCauseThePostpone.Any();
        }
        #endregion postponed nodes

        #region get initial configuration
        private void GetNodes()
        {
            _allNodes = LayoutAlgorithm.GetNodes(_diagram);
            SetNodesInitialPosition();

            if (_extendLayersToTransformations)
            {
                JoinDependentTransformationsToEntities();
            }
        }

        private void SetNodesInitialPosition()
        {
            if (_direction == ENetworkDirection.Downwards)
            {
                _allNodes.ForEach(x =>
                {
                    x.ManualYValue = x.RoundedInitialYUpValue;
                    x.ManualXValue = x.RoundedInitialXValue;
                });
            }
            else
            {
                _allNodes.ForEach(x =>
                {
                    x.ManualYValue = x.RoundedInitialYBottomValue;
                    x.ManualXValue = x.RoundedInitialXValue;
                });
            }
        }

        private void JoinDependentTransformationsToEntities()
        {
            var join = (from entityNodeInfo in _allNodes.Where(x => x.Content is NetworkEntityNode)
                        join transformationNodeInfo in _allNodes.Where(x => x.Content is NetworkTransformationNode)
                            on entityNodeInfo.Content.Id equals ((NetworkTransformationNode)transformationNodeInfo.Content).ParentId
                        select new
                        {
                            entityNodeInfo,
                            transformationNodeInfo
                        }).ToList();

            foreach (var j in join)
            {
                j.entityNodeInfo.DependentTransformationNodes.Add(j.transformationNodeInfo);
            }
        }
        #endregion get initial configuration

        #region computations on X axis

        private void SetXPositionInExistingRow(NodeInfo currentNode, List<NodeInfo> rowNodes)
        {
            // refresh occupied intervals based on already positioned nodes

            var occupiedIntervals = new List<Interval>();
            rowNodes.ForEach(x => occupiedIntervals.Add(new Interval
            {
                Start = x.ManualXValue,
                End = x.ManualXValue + x.Size.Width
            }));

            occupiedIntervals = occupiedIntervals.OrderBy(x => x.Start).ToList();

            // refresh free intervals based on already positioned nodes
            // consider the distance from existing nodes [MinimumHorizontalSpace]

            var freeIntervals = new List<Interval>();
            for (var i = 0; i < occupiedIntervals.Count - 1; i++)
            {
                freeIntervals.Add(new Interval
                {
                    Start = occupiedIntervals[i].End + MinimumHorizontalSpace,
                    End = occupiedIntervals[i + 1].Start - MinimumHorizontalSpace
                });
            }

            // we try to detect the correct X position and avoid overlapping                                     

            // check if the node fits on its initial X position

            if (!IsPositionAvailable(currentNode, freeIntervals, occupiedIntervals))
            {
                // find the best place: internal interval/ at the begining/at the end, whichever is closer

                var bigEnoughIntervals = freeIntervals.Where(x => Math.Abs(x.End - x.Start) >= currentNode.Size.Width).ToList();

                var beforeIntervalsX = occupiedIntervals.First().Start - MinimumHorizontalSpace;
                bigEnoughIntervals.Add(new Interval
                {
                    Start = beforeIntervalsX - currentNode.Size.Width,
                    End = beforeIntervalsX
                });

                var afterIntervalsX = occupiedIntervals.Last().End + MinimumHorizontalSpace;
                bigEnoughIntervals.Add(new Interval
                {
                    Start = afterIntervalsX,
                    End = afterIntervalsX + currentNode.Size.Width
                });

                // choose the closest interval 
                var minDistance = bigEnoughIntervals.Min(x => Math.Abs(x.Start - currentNode.ManualXValue));

                var foundInterval = bigEnoughIntervals.First(x =>
                    Math.Abs(x.Start - currentNode.ManualXValue).QuasiEqualTo(minDistance));

                currentNode.ManualXValue = foundInterval.Start;
            }
        }

        private void SetXPositionInExistingLayer(NodeInfo currentNode, PositionedLayerInfo positionedLayer)
        {
            SetXPositionInExistingRow(currentNode, positionedLayer.Nodes.Where(x => x != currentNode).ToList());
        }

        private bool IsPositionAvailable(NodeInfo node, List<Interval> freeIntervals, List<Interval> occupiedIntervals)
        {
            freeIntervals = freeIntervals.ToList();

            if (occupiedIntervals.Count == 0)
            {
                return true;
            }

            // add left and right side
            freeIntervals.Add(new Interval
            {
                Start = double.MinValue,
                End = occupiedIntervals.First().Start - MinimumHorizontalSpace
            });

            freeIntervals.Add(new Interval
            {
                Start = occupiedIntervals.Last().End + MinimumHorizontalSpace,
                End = double.MaxValue
            });

            // if the node fills with its initial X position in a free interval, then the position is available 

            return freeIntervals.Any(
                x => x.Start <= node.ManualXValue && node.ManualXValue + node.Size.Width <= x.End);
        }

        #endregion computations on X axis

        private void RelayoutDiagramItems()
        {
            var newPositions = _allNodes.Select(node => new PositionInfo<IDiagramItem>(node.Node, _direction == ENetworkDirection.Downwards ?
                node.FinalPositionDownwards : node.FinalPositionUpwards));

            _diagram.RelayoutDiagramItems(newPositions);

        }

        #endregion nodes positioning algorithm

        #region network layers creation

        private ObservableCollection<NetworkLayer> ComputeNetworkLayers()
        {
            if (_diagram.Items.Count == 0)
            {
                return new ObservableCollection<NetworkLayer>();
            }

            // all existing layers in the DataFlow
            _allLayers = GetDistinctLayers(_allNodes.ToList());

            _allNodesByRow = _allNodes.GroupBy(x => x.ManualYValue).OrderBy(x => x.Key).Select(x => x.ToList()).ToList();

            for (var i = 0; i < _allNodesByRow.Count; i++)
            {
                if (_allNodesByRow[i].Any(x => x.IsLayerAllowed))
                {
                    HandleRow(i);
                }
            }

            if (_postponedNodes.Any())
            {
                // we still have some uncovered cases
              throw
                (new Exception("Layers could not be displayed. Error ocurred for positioning the following nodes: " +
                               $"{string.Join(",", _postponedNodes.Select(x => x.Name))}"));

                return new ObservableCollection<NetworkLayer>();
            }

            RelayoutDiagramItems();

            return CreateLayers(_allNodes);
        }

        private ObservableCollection<NetworkLayer> CreateLayers(List<NodeInfo> nodes)
        {
            var layers = new ObservableCollection<NetworkLayer>();

            var orderedNodes = nodes.GroupBy(x => x.ManualYValue).OrderBy(x => x.Key).ToList();
            foreach (var orderedNodesGroup in orderedNodes)
            {
                var yPosition = orderedNodesGroup.Key;

                if (orderedNodesGroup.First().EntityNode != null &&
                    orderedNodesGroup.First().EntityNode.LayerInfo.Id != Constants.IdPredefinedLayerUnassigned)
                {
                    var layerHeight = GetNodesIncludingTransformationsMaxHeight(orderedNodesGroup.ToList());
                    var layer = CreateLayer(orderedNodesGroup.First().EntityNode.LayerInfo, yPosition, layerHeight);
                    layers.Add(layer);
                }
            }

            return layers;
        }

        private static double GetNodesIncludingTransformationsMaxHeight(List<NodeInfo> nodes)
        {
            var dependentTransformationNodes = nodes.SelectMany(x => x.DependentTransformationNodes).ToList();

            if (dependentTransformationNodes.Count == 0)
            {
                return nodes.Max(x => x.Size.Height);
            }

            var transformationsMaxHeight = dependentTransformationNodes.Max(x => x.Size.Height);
            var translationsMaxY = dependentTransformationNodes.First().ManualYValue + transformationsMaxHeight;
            return translationsMaxY - nodes.First().ManualYValue;
        }

        private static double GetNodesIncludingTransformationsBottomY(List<NodeInfo> nodes)
        {
            var dependentTransformationNodes = nodes.SelectMany(x => x.DependentTransformationNodes).ToList();

            if (dependentTransformationNodes.Count == 0)
            {
                return nodes.First().ManualYValue + nodes.Max(x => x.Size.Height);
            }

            var transformationsMaxHeight = dependentTransformationNodes.Max(x => x.Size.Height);
            var translationsMaxY = dependentTransformationNodes.First().ManualYValue + transformationsMaxHeight;
            return translationsMaxY;
        }

        private NetworkLayer CreateLayer(LayerInfo layerInfo, double yPosition, double height)
        {
            return new NetworkLayer
            {
                LayerInfo = layerInfo,
                Height = height + LayerPaddingUp + LayerPaddingDown,
                Left = 0,
                Top = yPosition - LayerPaddingUp
            };
        }

        #endregion network layers creation

        #region diagram containers management

        public void RemoveExistingContainers()
        {
            var existingContainers = _diagram.Items.OfType<DiagramContainer>().ToList();
            foreach (var container in existingContainers)
            {
                _diagram.Items.Remove(container);
            }
        }

        private void AddContainersToDiagram()
        {
            try
            {
                if (_diagram.Items.Count == 0)
                {
                    return;
                }

                var minX = _diagram.Items.Min(x => x.Position.X) - 100;
                var maxX = _diagram.Items.Max(x => x.Position.X) + _diagram.Items.OfType<DiagramContentItem>().First().Width + 10;
                var width = maxX - minX;

                foreach (var networkLayer in _networkData.NetworkLayers)
                {
                    var layerInfo = networkLayer.LayerInfo;
                    var container = new DiagramContainer
                    {
                        Header = layerInfo.Name,
                        ShowHeader = true,
                        DataContext = networkLayer,
                        Height = networkLayer.Height,
                        Width = width,
                        Position = new Point(minX, networkLayer.Top)
                    };

                    _diagram.Items.Add(container);
                    _diagram.SendItemsToBack(new List<DiagramItem> { container });
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        #endregion diagram containers management


    }
}