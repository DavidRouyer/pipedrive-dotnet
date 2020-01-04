using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pipedrive.Models.Common.Webhooks;

namespace Pipedrive
{
    public class NewWebhook
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewWebhook"/> class.
        /// </summary>
        /// <param name="subscriptionUrl">A full, valid, publicly accessible URL. Determines where to send the notifications. Please note that you cannot use Pipedrive API endpoints as the subscription_url.</param>
        /// <param name="eventAction">Type of action to receive notifications about. Wildcard will match all supported actions.</param>
        /// <param name="eventObject">Type of object to receive notifications about. Wildcard will match all supported objects.</param>
        public NewWebhook(string subscriptionUrl, EventAction eventAction, EventObject eventObject)
        {
            SubscriptionUrl = subscriptionUrl;
            EventAction = eventAction;
            EventObject = eventObject;
        }

        [JsonProperty("subscription_url")]
        public string SubscriptionUrl { get; set; }

        [JsonProperty("event_action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EventAction EventAction { get; set; }

        [JsonProperty("event_object")]
        [JsonConverter(typeof(StringEnumConverter))]
        public EventObject EventObject { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("http_auth_user")]
        public string HttpAuthUser { get; set; }

        [JsonProperty("http_auth_password")]
        public string HttpAuthPassword { get; set; }
    }
}
