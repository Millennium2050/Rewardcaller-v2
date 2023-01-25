using Microsoft.Azure.Cosmos;
namespace Rewardcaller.data
{
    public class CosmosContext 
    {
        private const string EndpointUrl = "yourCosmosdbConnenction";
        private const string AuthorizationKey = "yourKey";
        private const string DatabaseId = "yourDatabaseid";
        private const string ContainerId = "yourConaintername";

        public CosmosContext()
        {
           
        }

        public CosmosClient GetCosmosClient() {
            return new CosmosClient(EndpointUrl, AuthorizationKey);
        }

        public Container GetCosmosContainer()
        {
            return this.GetCosmosClient().GetContainer(DatabaseId, ContainerId);
        }
    }
}
