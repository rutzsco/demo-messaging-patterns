using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Dapr.PubSub.Publisher.Model;
using Dapr.Client;

namespace Demo.Dapr.PubSub.Publisher.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SimulationController : ControllerBase
    {
        private DaprClient _daprClient;
        private IConfiguration _configuration;

        public SimulationController(DaprClient daprClient, IConfiguration configuration)
        {
            _daprClient = daprClient;
            _configuration = configuration;
        }

        [HttpGet("publish")]
        public async Task<IActionResult> Publish()
        {
            await _daprClient.PublishEventAsync<Telemetry>("pubsub-servicebus", "telemetry", new Telemetry("ASSET001", "Tempurature", "32"));
            
            Console.WriteLine($"{DateTime.UtcNow} - Published event!");

            return new OkObjectResult("OK");
        }
    }
}
