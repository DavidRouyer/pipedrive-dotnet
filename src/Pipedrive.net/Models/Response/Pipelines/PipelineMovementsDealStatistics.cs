using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    public class PipelineMovementsDealStatistics
    {
        public long Count { get; set; }

        [JsonProperty("deal_ids")]
        public IReadOnlyList<string> DealIds { get; set; }

        [JsonProperty("values")]
        [JsonConverter(typeof(CurrencyValueConverter))]
        public IReadOnlyDictionary<string, decimal> Values { get; set; }

        [JsonProperty("formatted_values")]
        [JsonConverter(typeof(CurrencyFormattedValueConverter))]
        public IReadOnlyDictionary<string, string> FormattedValues { get; set; }
    }
}
