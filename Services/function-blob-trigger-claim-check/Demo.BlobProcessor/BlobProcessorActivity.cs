
using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Extensions.Logging;
using System.IO;

namespace Demo.BlobProcessor
{
    public static class BlobProcessorActivity
    {
        [FunctionName("BlobProcessorActivity")]
        public static void Run([BlobTrigger("messages/{name}", Source = BlobTriggerSource.EventGrid, Connection = "BlobStorageConnection")] Stream blobStream, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {blobStream.Length} Bytes");
        }
    }
}
