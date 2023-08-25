using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Animation;
using BusinessLogic;
using DevExpress.Diagram.Core;
using DevExpress.Diagram.Core.Layout;
using DevExpress.Mvvm.Native;
using DevExpress.Xpf.Diagram;

using ProjectB.Views.WPF.DataFlow_2_0.NetworkDisplayLayouts.Layout.Data;

namespace ProjectB.Views.WPF.DataFlow_2_0.NetworkDisplayLayouts.Layout
{
    public class LayoutAlgorithm
    {
        public static void Apply(DiagramControl diagram, bool useAnimation)
        {
            // based on the previously applied Sugiyama layout
            // -> adjust Y coordinate based on items size
            // -> update connector routes
            try
            {
                var nodes = GetNodes(diagram);
                ComputePositions(nodes);

                foreach (var node in nodes)
                {
                    Action callback = null;
                    if (node == nodes.Last())
                    {
                        callback = () =>
                        {
                            diagram.Items.OfType<IDiagramConnector>().ForEach(connector => { connector.UpdateRoute(); });
                            SaveNodeProperties(diagram);
                        };
                    }
                    MoveToPoint(node.Node, node.FinalPositionDownwards, useAnimation, callback);
                }

            }
            catch (Exception e)
            {
                throw;
            }
        }

        private static void ComputePositions(List<NodeInfo> nodes)
        {
            // take into consideration the stored position and size and compare them to the new ones
            // => establish the translation based on the difference
            // Y position is rounded to one decimal since the values after applying the built-in algorithm can have many decimals and groupping fails
            foreach (var rowGroup in nodes.GroupBy(x => x.RoundedInitialYUpValue))
            {
                var rowNodes = rowGroup.ToList();
                var maxStoredHeight = rowNodes.Max(x => x.Content.Size.Height);
                var maxCurrentHeight = rowNodes.Max(x => x.Size.Height);

                var translation = maxCurrentHeight - maxStoredHeight;
                var rowYPosition = rowNodes.First().RoundedInitialYUpValue;
                nodes.Where(x => x.RoundedInitialYUpValue > rowYPosition)
                    .ForEach(x => x.YTranslation += translation);
            }
          
        }    

        public static List<NodeInfo> GetNodes(DiagramControl diagram)
        {
            // get nodes content, size and position

            var nodes = new List<NodeInfo>();
            var graph = GraphOperations.GetDiagramGraph(diagram);
            graph.Nodes.OfType<DiagramContentItem>().ForEach(x => nodes.Add(new NodeInfo(x)));
            return nodes;
        }

        public static void SaveNodeProperties(DiagramControl diagram)
        {
            var nodes = diagram.Items.OfType<DiagramContentItem>();
            foreach (var node in nodes)
            {

                var content = (INetworkItem)node.Content;
                content.Position = node.Position;
                content.Size = node.RenderSize;
            }
        }

        private static void MoveToPoint(DiagramItem item, Point point, bool useAnimation, Action callback)
        {
            if (useAnimation)
            {
                var animation = new PointAnimation(point, new Duration(TimeSpan.FromSeconds(5.5)));

                void OnComplete(object s, EventArgs e)
                {
                    animation.Completed -= OnComplete;
                    item.BeginAnimation(DiagramItem.PositionProperty, null);
                    item.Position = point;
                    callback?.Invoke();
                }

                animation.Completed += OnComplete;
                item.BeginAnimation(DiagramItem.PositionProperty, animation);
            }
            else
            {
                item.Position = point;
            }
        }
    }
}
