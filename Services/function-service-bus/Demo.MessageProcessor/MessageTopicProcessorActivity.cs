using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Demo.MessageProcessor
{
    public class MessageTopicProcessorActivity
    {
        [FunctionName("MessageTopicProcessorActivity")]
        public void Run([ServiceBusTrigger("telemetry002", "FunctionProcesssor", Connection = "ServiceBusConnectionString")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
