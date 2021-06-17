using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    public class DealTimeline
    {
        [JsonProperty("period_start")]
        public DateTime PeriodStart { get; set; }

        [JsonProperty("period_end")]
        public DateTime PeriodEnd { get; set; }

        public IReadOnlyList<DealTimelineDeal> Deals { get; set; } = new List<DealTimelineDeal>();

        public DealTimelineTotals Totals { get; set; }
    }

    public class DealTimelineTotals
    {
        public long Count { get; set; }

        [JsonProperty("values")]
        [JsonConverter(typeof(CurrencyValueConverter))]
        public IReadOnlyDictionary<string, decimal> Values { get; set; }

        [JsonProperty("weighted_values")]
        [JsonConverter(typeof(CurrencyValueConverter))]
        public IReadOnlyDictionary<string, decimal> WeightedValues { get; set; }

        [JsonProperty("open_count")]
        public long OpenCount { get; set; }

        [JsonProperty("open_values")]
        [JsonConverter(typeof(CurrencyValueConverter))]
        public IReadOnlyDictionary<string, decimal> OpenValues { get; set; }

        [JsonProperty("weighted_open_values")]
        [JsonConverter(typeof(CurrencyValueConverter))]
        public IReadOnlyDictionary<string, decimal> WeightedOpenValues { get; set; }

        [JsonProperty("won_count")]
        public long WonCount { get; set; }

        [JsonProperty("won_values")]
        [JsonConverter(typeof(CurrencyValueConverter))]
        public IReadOnlyDictionary<string, decimal> WonValues { get; set; }
    }
}
