
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json.Linq;
using Rewardcaller.data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
namespace Rewardcaller.services
{
    public class DataService
    {
        private CosmosContext cosmosClient;
        private HttpClient httpContext;
        private int maxid = 0;
        public DataService()
        {
            cosmosClient = new CosmosContext();

            httpContext = new HttpClient();

            httpContext.DefaultRequestHeaders.Add("User-Agent", "C# App");
   
        }

        public List<CrusorObj> GetCursorItems()
        {
            var sqlQueryText = "SELECT * FROM c";

            Console.WriteLine("Running query: {0}\n", sqlQueryText);

            var container = cosmosClient.GetCosmosContainer();

            QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);

            var cursors = new List<CrusorObj>();

            var li = container.GetItemQueryIterator<CrusorObj>(queryDefinition).ReadNextAsync().Result;

            foreach (CrusorObj cursor in li)
            {
                cursors.Add(cursor);
                Console.WriteLine("\tRead {0}\n", cursor);
            }

            return cursors;
        }

        public bool CheckCursor(string cursor, out int maxid) {

            var items = GetCursorItems();

            maxid = items.Max(i => int.Parse(i.id));

            if (string.IsNullOrEmpty(cursor))
                return false;

            return items.Where(l=>l.cursor == cursor).Any();

        }

        public void AddCursorItems()
        {
            var cursor = string.Empty;

            var respone = httpContext.GetAsync("https://api.helium.io/v1/accounts/13acHn71cCd7G1Y9Nx57UMdsgv6GQarf3kZqVb4CzojQiz64ZJG/rewards?min_time=-7%20day");

            var res = respone.Result;

            var content = res.Content.ReadAsStringAsync().Result;

            JObject content2Json = JObject.Parse(content);

            if (content2Json != null)
                cursor = (content2Json["cursor"]).ToString();

            Console.WriteLine("\tRead {0}\n", cursor);

            if (CheckCursor(cursor, out maxid))
            {
                return;
            }

            ++maxid;
            var container = cosmosClient.GetCosmosContainer();

            var ob = new CrusorObj() { cursor = cursor , id = maxid.ToString() };

            container.CreateItemAsync<CrusorObj>(ob, new PartitionKey(ob.id));
            
        }
    }
}
