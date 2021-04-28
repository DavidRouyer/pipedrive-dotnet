using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pipedrive.Webhooks
{
    /// <summary>
    /// Pipedrive webhook meta block https://pipedrive.readme.io/docs/guide-for-webhooks#section-webhooks-meta-block
    /// </summary>
    public class Meta
    {
        [JsonProperty("v")]
        public long V { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("company_id")]
        public long? CompanyId { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("host")]
        public string Host { get; set; }

        [JsonProperty("timestamp")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime Timestamp { get; set; }

        [JsonProperty("timestamp_micro")]
        public string TimestampMicro { get; set; }

        [JsonProperty("permitted_user_ids")]
        public string[] PermittedUserIds { get; set; }

        [JsonProperty("trans_pending")]
        public bool? TransPending { get; set; }

        [JsonProperty("is_bulk_update")]
        public bool IsBulkUpdate { get; set; }

        [JsonProperty("pipedrive_service_name")]
        public string PipedriveServiceName { get; set; }

        [JsonProperty("matches_filters")]
        public MatchesFilters MatchesFilters { get; set; }

        [JsonProperty("webhook_id")]
        public string WebhookId { get; set; }
    }
}
