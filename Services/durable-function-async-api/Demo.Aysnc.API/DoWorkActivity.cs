using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace Demo.Aysnc.API
{
    public static class DoWorkActivity
    {
        [FunctionName("DoWorkActivity")]
        public static string Run([ActivityTrigger] int waitSeconds, ILogger log)
        {
            Thread.Sleep(waitSeconds * 1000);
            return $"OK";
        }
    }
}