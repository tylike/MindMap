using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
   public class NetworkData : NotificationObject
    {
        private ObservableCollection<NetworkNode> _networkNodes;
        
        public ObservableCollection<NetworkNode> NetworkNodes
        {
            get => _networkNodes;
            set => SetField(ref _networkNodes, value, nameof(NetworkNodes));
        }

        private ObservableCollection<NetworkConnector> _networkConnectors;
        public ObservableCollection<NetworkConnector> NetworkConnectors
        {
            get => _networkConnectors;
            set => SetField(ref _networkConnectors, value, "NetworkConnectors");
        }

        private ObservableCollection<NetworkLayer> _networkLayers;
        public ObservableCollection<NetworkLayer> NetworkLayers
        {
            get => _networkLayers;
            set => SetField(ref _networkLayers, value, "NetworkLayers");
        }

        public List<INetworkItem> AllItems
        {
            get
            {
                var allNetworkItems = new List<INetworkItem>();
                allNetworkItems.AddRange(NetworkNodes);
                allNetworkItems.AddRange(NetworkConnectors);
                return allNetworkItems;
            }
        }

        public IEnumerable<NetworkEntityNode> EntityNodes => NetworkNodes.OfType<NetworkEntityNode>();
        public IEnumerable<NetworkTransformationNode> TransformationNodes => NetworkNodes.OfType<NetworkTransformationNode>();

        public NetworkData()
        {
            Reset();
        }

        public NetworkData(List<NetworkNode> nodes, List<NetworkConnector> connectors)
        {
            NetworkNodes = new ObservableCollection<NetworkNode>(nodes);
            NetworkConnectors = new ObservableCollection<NetworkConnector>(connectors);
            NetworkLayers = new ObservableCollection<NetworkLayer>();
        }

        public void Reset()
        {
            NetworkLayers = new ObservableCollection<NetworkLayer>();
            NetworkNodes = new ObservableCollection<NetworkNode>();
            NetworkConnectors = new ObservableCollection<NetworkConnector>();
        }
    }

   public class NetworkLayer : NotificationObject
   {
       private LayerInfo _layerInfo;
       private double _height;
       private double _top;
       private double _left;

       public LayerInfo LayerInfo
       {
           get => _layerInfo;
           set => SetField(ref _layerInfo, value, "LayerInfo");
       }

       public double Height
       {
           get => _height;
           set => SetField(ref _height, value, "Height");
       }

       public double Top
       {
           get => _top;
           set => SetField(ref _top, value, "Top");
       }

       public double Left
       {
           get => _left;
           set => SetField(ref _left, value, "Left");
       }

       public override string ToString()
       {
           return LayerInfo == null ?
               $"<Empty LayerInfo>, Top: {Top}" :
               $"{LayerInfo.Name}- Order: {LayerInfo.OrderNo}, Top: {Top}";
       }
   }
}
