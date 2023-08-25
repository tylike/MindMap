using System.Collections.ObjectModel;
using System.IO;
using BusinessLogic.Data;

namespace BusinessLogic
{
    public static class NetworkDeserializeProvider
    {
        private const string Location = @"Examples";
        // private const string Location = @"D:\SerializedNetworks";

        public static NetworkData Deserialize(string filename)
        {
            var serializableDataPool = SerializerHelper.DeSerializeObject<SerializableDataPool>(Path.Combine(Location, filename));
            return new NetworkData
            {
                NetworkNodes = new ObservableCollection<NetworkNode>(serializableDataPool.Nodes),
                NetworkConnectors = new ObservableCollection<NetworkConnector>(serializableDataPool.Connectors)
            };
        }
    }
}
