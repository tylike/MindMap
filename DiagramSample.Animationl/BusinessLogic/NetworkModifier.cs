using BusinessLogic.Data;

namespace BusinessLogic
{
    public class NetworkModifier
    {
        public void UpdateNetwork(NetworkData networkData)
        {
            foreach (var node in networkData.NetworkNodes)
            {
              //  node.Description = "Description -> Mos Craciun cu plete dalbe ";
            //  node.Description = "Desc";
            }
        }
    }
}
