using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pipedrive
{
    public class NewWebhook
    {
        [JsonProperty("subscription_url")]
        public string SubscriptionUrl { get; set; }

        [JsonProperty("event_action")]
        public string EventAction { get; set; }

        [JsonProperty("event_object")]
        public string EventObject { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("http_auth_user")]
        public string HttpAuthUser { get; set; }

        [JsonProperty("http_auth_password")]
        public string HttpAuthPassword { get; set; }

        [JsonIgnore]
        private readonly List<string> _validEventActions = new List<string>
        {
            "added",
            "updated",
            "merged",
            "deleted",
            "*"
        };

        [JsonIgnore]
        private readonly List<string> _validEventObjects = new List<string>
        {
            "activity",
            "activityType",
            "deal",
            "note",
            "organization",
            "person",
            "pipeline",
            "product",
            "stage",
            "user",
            "*"
        };

        public NewWebhook(string subscriptionUrl, string eventAction, string eventObject)
        {
            if (!_validEventActions.Contains(eventAction.ToLower())) throw new ArgumentOutOfRangeException($"eventAction is invalid, please use one of the following values: { string.Join(",", _validEventActions) }");
            if (!_validEventObjects.Contains(eventObject.ToLower())) throw new ArgumentOutOfRangeException($"eventObject is invalid, please use one of the following values: { string.Join(",", _validEventObjects) }");

            SubscriptionUrl = subscriptionUrl;
            EventAction = eventAction.ToLower();
            EventObject = eventObject.ToLower();
        }
    }
}
