using Dapr;
using Dapr.Client;
using Demo.Dapr.PubSub.Subscriber.Model;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Dapr.PubSub.Subscriber.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TelemetryController : ControllerBase
    {
        private DaprClient _daprClient;
        private IConfiguration _configuration;

        public TelemetryController(DaprClient daprClient, IConfiguration configuration)
        {
            _daprClient = daprClient;
            _configuration = configuration;
        }

        [Topic("pubsub-sb", "telemetry")]
        [HttpPost("processtelemetry")]
        public async Task ProcessTelemetry([FromBody] TelemetryData telemetryData)
        {
            try
            {
                Console.WriteLine($"{DateTime.UtcNow} - Event received processrabbitmq - AssetId: {telemetryData.AssetId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
