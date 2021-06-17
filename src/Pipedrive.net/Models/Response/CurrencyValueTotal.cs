using Newtonsoft.Json;

namespace Pipedrive
{
    public class CurrencyValueTotal
    {
        public long Value { get; set; }

        public long Count { get; set; }

        [JsonProperty("value_converted")]
        public decimal ValueConverted { get; set; }

        [JsonProperty("value_formatted")]
        public string ValueFormatted { get; set; }

        [JsonProperty("value_converted_formatted")]
        public string ValueConvertedFormatted { get; set; }
    }
}
