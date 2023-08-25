using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
using BusinessLogic.Data;
using DevExpress.Diagram.Core;
using DevExpress.Diagram.Core.Native;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Diagram;
using DevExpress.Xpf.Diagram.Native;

using ProjectB.Views.WPF.Controls.NetworkDataFlow;
using ProjectB.Views.WPF.Controls.NetworkDataFlow.Data;
using ProjectB.Views.WPF.DataFlow_2_0.NetworkDisplayLayouts.Layers;
using WpfProject.App.NetworkCustomization.LayoutAlgorithms.Layout.Data;


namespace ProjectB.Views.WPF.DataFlow_2_0.NetworkDisplayLayouts.Layout
{
    public static class LayoutExtensions
    {
        #region refresh
        public static void Refresh(this WpfNetworkDataFlow networkDataFlow, LayoutRefreshRequestEventArgs args, NetworkData networkData)
        {
            networkDataFlow.Dispatcher?.BeginInvoke(new Action(() =>
            {
                networkDataFlow.Diagram.ReactToZoomChanged = false;

                var layersAlgorithm = new LayersAlgorithm(networkData, networkDataFlow.Diagram, args.Direction, args.ExtendLayersToTransformations);

                layersAlgorithm.RemoveExistingContainers();

                var oldZoomFactor = networkDataFlow.Diagram.ZoomFactor;

                if (args.DesiredZoomFactor > 0)
                {
                    networkDataFlow.Diagram.ZoomFactor = args.DesiredZoomFactor > 0 ? args.DesiredZoomFactor : oldZoomFactor;
                }

                if (args.ApplySugiyama || args.ShowLayers)
                {
                    DiagramItem item = null;

                    if (item != null)
                    {
                        //https://supportcenter.devexpress.com/ticket/details/t889783/unexpected-diagram-shift-down

                        var itemBounds = item.ClientBounds();
                        var diagramViewport = networkDataFlow.Diagram.GetViewportBounds();
                        var leftOffset = itemBounds.X - diagramViewport.X;
                        var topOffset = itemBounds.Y - diagramViewport.Y;

                        networkDataFlow.Diagram.ApplySugiyamaLayout(args.Direction == ENetworkDirection.Downwards
                            ? DevExpress.Diagram.Core.Direction.Down
                            : DevExpress.Diagram.Core.Direction.Up);
                        networkDataFlow.Diagram.ScrollToPoint(new Point(item.Position.X - leftOffset, item.Position.Y - topOffset), HorizontalAlignment.Left, VerticalAlignment.Top);
                    }
                    else
                    {
                        networkDataFlow.Diagram.ApplySugiyamaLayout(args.Direction == ENetworkDirection.Downwards
                            ? DevExpress.Diagram.Core.Direction.Down
                            : DevExpress.Diagram.Core.Direction.Up);
                    }
                    networkDataFlow.Diagram.Connectors().ForEach(x => x.UpdateRoute());
                }
                else if (args.SimpleRefresh)
                {
                    LayoutAlgorithm.Apply(networkDataFlow.Diagram, args.UseAnimation);
                }

                if (networkData != null)
                {
                    if (args.ShowLayers)
                    {
                        layersAlgorithm.Apply();
                    }
                    else
                    {
                        networkData.NetworkLayers.Clear();
                    }
                }

                if (args.DesiredZoomFactor > 0)
                {
                    networkDataFlow.Diagram.ZoomFactor = args.DesiredZoomFactor > 0 ? args.DesiredZoomFactor : oldZoomFactor;
                }

                if (args.UpdateRoutes)
                {
                    networkDataFlow.Diagram.Connectors().ForEach(x => x.UpdateRoute());
                }

                if (!args.ShowLayers)
                {
                  //  LayoutAlgorithm.SaveNodeProperties(networkDataFlow.Diagram, args.Direction);
                }

                networkDataFlow.Diagram.ReactToZoomChanged = true;

            }),
                DispatcherPriority.ContextIdle);
        }

        #endregion refresh
    }
}
