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

        /// <summary>
        /// Initializes a new instance of the <see cref="NewWebhook"/> class.
        /// </summary>
        /// <param name="subscriptionUrl">A full, valid, publicly accessible URL. Determines where to send the notifications. Please note that you cannot use Pipedrive API endpoints as the subscription_url.</param>
        /// <param name="eventAction">Type of action to receive notifications about. Wildcard will match all supported actions.</param>
        /// <param name="eventObject">Type of object to receive notifications about. Wildcard will match all supported objects.</param>
        /// <exception cref="ArgumentOutOfRangeException">Will throw if eventAction or eventObject are not valid values</exception>
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
