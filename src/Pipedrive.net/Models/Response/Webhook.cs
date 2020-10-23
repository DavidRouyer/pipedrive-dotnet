using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class Webhook
    {
        public long Id { get; set; }

        [JsonProperty("company_id")]
        public long? CompanyId { get; set; }

        [JsonProperty("owner_id")]
        public long? OwnerId { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("admin_id")]
        public long? AdminId { get; set; }

        [JsonProperty("event_action")]
        public string EventAction { get; set; }

        [JsonProperty("event_object")]
        public string EventObject { get; set; }

        [JsonProperty("subscription_url")]
        public string SubscriptionUrl { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("add_time")]
        public DateTime? AddTime { get; set; }

        [JsonProperty("remove_time")]
        public DateTime? RemoveTime { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("remove_reason")]
        public string RemoveReason { get; set; }

        [JsonProperty("http_auth_user")]
        public string HttpAuthUser { get; set; }

        [JsonProperty("http_auth_password")]
        public string HttpAuthPassword { get; set; }

        [JsonProperty("last_delivery_time")]
        public DateTime? LastDeliveryTime { get; set; }

        [JsonProperty("last_http_status")]
        public int? LastHttpStatus { get; set; }
    }
}
