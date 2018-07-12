using Newtonsoft.Json;
using Pipedrive.Converters;

namespace Pipedrive.Webhooks
{
    public class WebhookResponse<T> : IWebhookResponse<T>
    {
        [JsonProperty("v")]
        public long V { get; set; }

        [JsonProperty("matches_filters")]
        public MatchesFilters MatchesFilters { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonConverter(typeof(WebhookNullConverter))]
        [JsonProperty("previous")]
        public T Previous { get; set; }

        [JsonConverter(typeof(WebhookNullConverter))]
        [JsonProperty("current")]
        public T Current { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("retry")]
        public long Retry { get; set; }
    }
}
