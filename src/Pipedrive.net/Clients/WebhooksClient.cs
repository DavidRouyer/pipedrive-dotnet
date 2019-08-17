using Newtonsoft.Json;
using Pipedrive.Webhooks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Webhook API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Webhooks">Webhook API documentation</a> for more information.
    public class WebhooksClient : IWebhooksClient
    {
        public IWebhookResponse<WebhookDeal> ParseWebhookDealResponse(string request)
        {
            return JsonConvert.DeserializeObject<WebhookResponse<WebhookDeal>>(request);
        }

        public IWebhookResponse<Activity> ParseWebhookActivityResponse(string request)
        {
            return JsonConvert.DeserializeObject<WebhookResponse<Activity>>(request);
        }

        public IWebhookResponse<WebhookOrganization> ParseWebhookOrganizationResponse(string request)
        {
            return JsonConvert.DeserializeObject<WebhookResponse<WebhookOrganization>>(request);
        }
    }
}
