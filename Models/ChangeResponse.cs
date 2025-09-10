using System.Text.Json.Serialization;

namespace ChangeCalculator.API.Models
{
    public class ChangeResponse
    {
        [JsonPropertyName("R200")]
        public int R200 { get; set; }

        [JsonPropertyName("R100")]
        public int R100 { get; set; }

        [JsonPropertyName("R50")]
        public int R50 { get; set; }

        [JsonPropertyName("R20")]
        public int R20 { get; set; }

        [JsonPropertyName("R10")]
        public int R10 { get; set; }

        [JsonPropertyName("R5")]
        public int R5 { get; set; }

        [JsonPropertyName("R2")]
        public int R2 { get; set; }

        [JsonPropertyName("R1")]
        public int R1 { get; set; }

        [JsonPropertyName("50c")]
        public int FiftyC { get; set; }

        [JsonPropertyName("20c")]
        public int TwentyC { get; set; }

        [JsonPropertyName("10c")]
        public int TenC { get; set; }
    }
}