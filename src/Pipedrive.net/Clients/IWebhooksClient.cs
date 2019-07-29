using Pipedrive.Webhooks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Webhook API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Webhooks">Webhook API documentation</a> for more information.
    public interface IWebhooksClient
    {
        IWebhookResponse<WebhookDeal> ParseWebhookDealResponse(string request);

        IWebhookResponse<Activity> ParseWebhookActivityResponse(string request);

        IWebhookResponse<WebhookOrganization> ParseWebhookOrganizationResponse(string request);
    }
}
