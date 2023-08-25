using System.Collections.Generic;

namespace BusinessLogic.Data
{
    public class SerializableDataPool
    {
        public List<NetworkNode> Nodes { get; set; }
        public List<NetworkConnector> Connectors { get; set; }
    }
}
