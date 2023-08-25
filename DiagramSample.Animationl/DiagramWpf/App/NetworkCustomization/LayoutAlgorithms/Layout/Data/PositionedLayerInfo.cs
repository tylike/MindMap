using System.Collections.Generic;
using System.Linq;
using BusinessLogic;

namespace ProjectB.Views.WPF.DataFlow_2_0.NetworkDisplayLayouts.Layout.Data
{
    public class PositionedLayerInfo
    {
        public LayerInfo LayerInfo { get; set; }

        public List<NodeInfo> Nodes { get; set; }

        public double HeightIncludingTransformations { get; set; }

        public double YPosition
        {
            get
            {
                if (Nodes.Count == 0)
                {
                    return 0;
                }

                return Nodes.First().ManualYValue;
            }
        }

        public PositionedLayerInfo(LayerInfo layerInfo)
        {
            LayerInfo = layerInfo;
            Nodes = new List<NodeInfo>();
        }

        public override string ToString()
        {
            return $"{LayerInfo.Name}-{YPosition}-{HeightIncludingTransformations}";
        }
    }
}
