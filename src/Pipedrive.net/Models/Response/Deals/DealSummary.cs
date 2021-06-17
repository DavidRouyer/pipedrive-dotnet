using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    public class DealSummary
    {
        [JsonProperty("values_total")]
        [JsonConverter(typeof(ValueTotalConverter))]
        public IReadOnlyDictionary<string, ValueTotal> ValuesTotal { get; set; }

        [JsonProperty("weighted_values_total")]
        [JsonConverter(typeof(ValueTotalConverter))]
        public IReadOnlyDictionary<string, ValueTotal> WeightedValuesTotal { get; set; }

        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("total_currency_converted_value")]
        public long TotalCurrencyConvertedValue { get; set; }

        [JsonProperty("total_weighted_currency_converted_value")]
        public long TotalWeightedCurrencyConvertedValue { get; set; }

        [JsonProperty("total_currency_converted_value_formatted")]
        public string TotalCurrencyConvertedValueFormatted { get; set; }

        [JsonProperty("total_weighted_currency_converted_value_formatted")]
        public string TotalWeightedCurrencyConvertedValueFormatted { get; set; }
    }
}
