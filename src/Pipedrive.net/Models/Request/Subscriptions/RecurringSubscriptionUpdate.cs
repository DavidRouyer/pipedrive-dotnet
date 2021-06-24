using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Converters;

namespace Pipedrive
{
    public class RecurringSubscriptionUpdate
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cycle_amount", NullValueHandling = NullValueHandling.Ignore)]
        public decimal CycleAmount { get; set; }

        [JsonProperty("payments", NullValueHandling = NullValueHandling.Ignore)]
        public List<NewPayment> Payments { get; set; }

        [JsonProperty("update_deal_value")]
        public bool UpdateDealValue { get; set; }

        [JsonProperty("effective_date")]
        [JsonConverter(typeof(DateWithoutTimeConverter))]
        public DateTime EffectiveDate { get; set; }
    }
}
