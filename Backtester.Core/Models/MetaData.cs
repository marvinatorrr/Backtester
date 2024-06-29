using System.Text.Json.Serialization;

namespace Backtester.Core.Models
{
    public class MetaData
    {
        public string Symbol { get; set; }
        public string Interval { get; set; }
        public string Currency { get; set; }
        [JsonPropertyName("exchange_timezone")]
        public string ExchangeTimezone { get; set; }
        public string Exchange { get; set; }
        public string Type { get; set; }
    }
}