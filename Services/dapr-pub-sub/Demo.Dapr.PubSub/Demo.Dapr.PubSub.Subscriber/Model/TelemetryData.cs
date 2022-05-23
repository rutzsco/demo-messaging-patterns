using System.Text.Json.Serialization;

namespace Demo.Dapr.PubSub.Subscriber.Model
{
    public class TelemetryData
    {
        public TelemetryData(string assetId, string metricName, string metricValue)
        {
            AssetId = assetId;
            MetricName = metricName;
            MetricValue = metricValue;
        }

        [JsonPropertyName("assetId")]
        public string AssetId { get; set; }

        [JsonPropertyName("metricName")]
        public string MetricName { get; set; }

        [JsonPropertyName("metricValue")]
        public string MetricValue { get; set; }
    }
}
