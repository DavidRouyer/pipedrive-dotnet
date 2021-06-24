using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class InstallmentSubscriptionUpdate
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("payments")]
        public List<NewPayment> Payments { get; set; }

        [JsonProperty("update_deal_value")]
        public bool UpdateDealValue { get; set; }
    }
}
