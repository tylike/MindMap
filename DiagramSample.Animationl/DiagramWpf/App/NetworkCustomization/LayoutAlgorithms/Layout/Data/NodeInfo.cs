using System;
using System.Collections.Generic;
using System.Windows;
using BusinessLogic;
using DevExpress.Diagram.Core;
using DevExpress.Xpf.Diagram;

namespace ProjectB.Views.WPF.DataFlow_2_0.NetworkDisplayLayouts.Layout.Data
{
    public class NodeInfo
    {
        private readonly Point _initialPosition;

        public DiagramContentItem Node { get; set; }
        public Size Size { get; set; }
        public double XTranslation { get; set; }
        public double YTranslation { get; set; }

        public bool ManuallyYChanged { get; set; }
        public bool ManuallyXChanged { get; set; }

        private double _manualYValue;
        public double ManualYValue
        {
            get => _manualYValue;
            set
            {
                _manualYValue = value;
                ManuallyYChanged = true;
            }
        }

        private double _manualXValue;
        public double ManualXValue
        {
            get => _manualXValue;
            set
            {
                _manualXValue = value;
                ManuallyXChanged = true;
            }
        }

        public NetworkEntityNode EntityNode
        {
            get
            {
                if (Node.Content is NetworkEntityNode entityNode)
                {
                    return entityNode;
                }
                return null;
            }
        }

        public List<NodeInfo> DependentTransformationNodes { get; set; } = new List<NodeInfo>();

        public bool IsLayerAllowed => EntityNode != null;

        public INetworkItem Content => (INetworkItem)Node.Content;

        public double RoundedInitialYUpValue => Math.Round(_initialPosition.Y, 1);
        public double RoundedInitialYBottomValue => Math.Round(_initialPosition.Y + Size.Height, 1);
        public double RoundedInitialXValue => Math.Round(_initialPosition.X, 1);

        public Point FinalPositionDownwards =>
            new Point(
                FinalPositionX,
                ManuallyYChanged ? ManualYValue : _initialPosition.Y + YTranslation);

        public Point FinalPositionUpwards =>
            new Point(
                FinalPositionX,
                ManuallyYChanged ? ManualYValue : _initialPosition.Y - YTranslation);

        public double FinalPositionX => ManuallyXChanged ? ManualXValue : _initialPosition.X + XTranslation;

        // only for debugging
        public string Name
        {
            get
            {
                if (EntityNode != null)
                {
                    return EntityNode.Title;
                }
                if (Node.Content is NetworkTransformationNode transfNode)
                {
                    return transfNode.Description;
                }
                return Node.Content.ToString();
            }
        }

        public LayerInfo LayerInfo
        {
            get
            {
                if (Node.Content is NetworkEntityNode entityNode)
                {
                    return entityNode.LayerInfo;
                }
                return null;
            }
        }

        public NodeInfo(IDiagramItem node)
        {
            Node = (DiagramContentItem)node;
            _initialPosition = Node.Position;
            Size = Node.RenderSize;
        }

        public override string ToString()
        {
            return $"{Name}: [X= {_initialPosition.X}, Y= {_initialPosition.Y}]," +
                   $" [Width= {Size.Width},  Height= {Size.Height}]";
        }
    }

   
  
}
