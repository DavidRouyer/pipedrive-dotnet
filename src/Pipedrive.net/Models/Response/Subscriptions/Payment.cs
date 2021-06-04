using System;
using Newtonsoft.Json;
using Pipedrive.Converters;

namespace Pipedrive
{
    public class Payment
    {
        public long Id { get; set; }

        [JsonProperty("subscription_id")]
        public long SubscriptionId { get; set; }

        [JsonProperty("deal_id")]
        public long DealId { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("change_amount")]
        public long ChangeAmount { get; set; }

        [JsonProperty("due_at")]
        [JsonConverter(typeof(DateWithoutTimeConverter))]
        public DateTime? DueAt { get; set; }

        [JsonProperty("revenue_movement_type")]
        public string RevenueMovementType { get; set; }

        [JsonProperty("payment_type")]
        public string PaymentType { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }
    }
}
