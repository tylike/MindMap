using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using BusinessLogic;
using BusinessLogic.Data;
using DevExpress.Mvvm.Native;
using DiagramWpf;
using WpfProject.App.NetworkCustomization.LayoutAlgorithms.Layout.Data;

namespace WpfProject.App
{
    public delegate void LayoutRefreshRequestHandler(LayoutRefreshRequestEventArgs e);

    public class AppViewModel : NotificationObject
    {
        public event LayoutRefreshRequestHandler LayoutRefreshRequested;

        private NetworkData _networkData;
        public NetworkData NetworkData
        {
            get => _networkData;
            set
            {
                _networkData = value;
                OnPropertyChanged("NetworkData");
            }
        }

        private RelayCommand _applyStateToAllTransformationsCommand;
        public ICommand ApplyStateToAllTransformationsCommand
            => _applyStateToAllTransformationsCommand ?? (_applyStateToAllTransformationsCommand =
                new RelayCommand(ApplyStateToAllTansformationsCommandExecuted));

        public AppViewModel()
        {
            AssignNetworkData();
        }

        private void AssignNetworkData()
        {
            var networkData = NetworkDeserializeProvider.Deserialize("VMM_M001.txt");
            //var networkData = NetworkDeserializeProvider.Deserialize("ZPURV01.txt");

            new NetworkModifier().UpdateNetwork(networkData);

            foreach (var node in networkData.NetworkNodes.Where(x => x.NodeType == NetworkFlowNodeType.Transformation))
            {
                node.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == "IsExpanded")
                    {
                        OnLayoutRefreshRequested(new LayoutRefreshRequestEventArgs
                        {
                            SimpleRefresh = true,
                            ShowLayers = false,
                            ExtendLayersToTransformations = false,
                            UseAnimation = true
                        });
                    }
                };
            }

            NetworkData = networkData;
        }

        private void ApplyStateToAllTansformationsCommandExecuted(object obj)
        {
            if (!NetworkData.TransformationNodes.Any())
            {
                return;
            }

            ReactToNodesContentChange = false;
            NetworkData.TransformationNodes
                .ForEach(x => x.IsExpanded = true);
            ReactToNodesContentChange = true;
            OnLayoutRefreshRequested(new LayoutRefreshRequestEventArgs()
            {
                SimpleRefresh = true,
                ShowLayers = false,
                ExtendLayersToTransformations = false,
                ApplySugiyama = false
            });
        }

        public bool ReactToNodesContentChange { get; set; }

        protected virtual void OnLayoutRefreshRequested(LayoutRefreshRequestEventArgs e)
        {
            LayoutRefreshRequested?.Invoke(e);
        }
    }
}
