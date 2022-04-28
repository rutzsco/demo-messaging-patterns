
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Demo.BlobProcessor
{
    public static class BlobProcessorActivity
    {
        [FunctionName("BlobProcessorActivity")]
        public static async Task Run([EventGridTrigger] EventGridEvent eventGridEvent, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Data:{eventGridEvent.Data}");
        }
    }
}
