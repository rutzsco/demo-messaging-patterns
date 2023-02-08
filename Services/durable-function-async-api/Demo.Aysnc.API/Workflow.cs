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
    public static class Workflow
    {

        [FunctionName("Workflow")]
        public static async Task<List<string>> RunOrchestrator([OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var outputs = new List<string>();
            var duration = context.GetInput<int>();
            outputs.Add(await context.CallActivityAsync<string>("DoWorkActivity", duration / 3));
            outputs.Add(await context.CallActivityAsync<string>("DoWorkActivity", duration / 3));
            outputs.Add(await context.CallActivityAsync<string>("DoWorkActivity", duration / 3));
            return outputs;
        }
    }
}