using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectB.Views.WPF.Controls.NetworkDataFlow.Data;

namespace WpfProject.App.NetworkCustomization.LayoutAlgorithms.Layout.Data
{
    public  class LayoutRefreshRequestEventArgs : EventArgs
    {
        public ENetworkDirection Direction { get; set; }
        public bool ApplySugiyama { get; set; }

        public bool SimpleRefresh { get; set; }
        public bool UpdateRoutes { get; set; }

        public bool ShowLayers { get; set; }

        public bool Zooming { get; set; }

        public double DesiredZoomFactor { get; set; }

        public bool UseAnimation { get; set; }

        public bool ExtendLayersToTransformations { get; set; }

        public LayoutRefreshRequestEventArgs()
        {

        }

    }
}
