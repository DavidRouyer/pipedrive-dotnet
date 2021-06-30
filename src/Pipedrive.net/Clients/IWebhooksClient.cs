using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Webhooks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Webhook API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/Webhooks">Webhook API documentation</a> for more information.
    public interface IWebhooksClient
    {
        Task<IReadOnlyList<Webhook>> GetAll();

        Task<Webhook> Create(NewWebhook data);

        Task Delete(long id);

        IWebhookResponse<WebhookDeal> ParseWebhookDealResponse(string request);

        IWebhookResponse<Activity> ParseWebhookActivityResponse(string request);

        IWebhookResponse<WebhookOrganization> ParseWebhookOrganizationResponse(string request);

        IWebhookResponse<WebhookPerson> ParseWebhookPersonResponse(string request);
    }
}
