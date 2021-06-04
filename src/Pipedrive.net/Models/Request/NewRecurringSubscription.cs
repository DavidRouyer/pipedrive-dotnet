using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Converters;

namespace Pipedrive
{
    public class NewRecurringSubscription
    {
        [JsonProperty("deal_id")]
        public long DealId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cadence_type")]
        public string CadenceType { get; set; }

        [JsonProperty("cycles_count", NullValueHandling = NullValueHandling.Ignore)]
        public long? CyclesCount { get; set; }

        [JsonProperty("cycle_amount", NullValueHandling = NullValueHandling.Ignore)]
        public long CycleAmount { get; set; }

        [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(DateWithoutTimeConverter))]
        public DateTime? StartDate { get; set; }

        [JsonProperty("infinite", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Infinite { get; set; }

        [JsonProperty("payments")]
        public List<NewPayment> Payments { get; set; }

        [JsonProperty("update_deal_value")]
        public bool UpdateDealValue { get; set; }
    }
}
