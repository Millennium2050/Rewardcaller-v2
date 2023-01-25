using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Rewardcaller.services;
using System.Text.Json;
namespace Rewardcaller
{
    public class RefershCursor
    {
        [FunctionName("RefershCursor")]
        public void Run([TimerTrigger("0 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            var service = new DataService();

            List<CrusorObj> objs = service.GetCursorItems();

            service.AddCursorItems();

            //var json = JsonSerializer.Serialize(objs);

            //log.LogInformation(json);
        }
    }
}
