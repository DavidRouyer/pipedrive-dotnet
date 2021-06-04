using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class Subscription
    {
        public long Id { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("deal_id")]
        public long DealId { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("cycle_amount")]
        public decimal CycleAmount { get; set; }

        [JsonProperty("cycles_count")]
        public long CyclesCount { get; set; }

        [JsonProperty("infinite")]
        public bool Infinite { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("add_time")]
        public string AddTime { get; set; }

        [JsonProperty("update_time")]
        public string UpdateTime { get; set; }

        [JsonProperty("lifetime_value")]
        public decimal LifetimeValue { get; set; }

        [JsonProperty("cadence_type")]
        public string CadenceType { get; set; }

        [JsonProperty("final_status")]
        public string FinalStatus { get; set; }
    }
}
