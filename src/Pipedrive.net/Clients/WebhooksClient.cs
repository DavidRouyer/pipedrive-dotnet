using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Pipedrive.Helpers;
using Pipedrive.Webhooks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Webhook API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Webhooks">Webhook API documentation</a> for more information.
    public class WebhooksClient : ApiClient, IWebhooksClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebhooksClient"/> class.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public WebhooksClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Webhook>> GetAll()
        {
            return ApiConnection.GetAll<Webhook>(ApiUrls.Webhooks());
        }

        public Task<Webhook> Create(NewWebhook data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<Webhook>(ApiUrls.Webhooks(), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.Webhook(id));
        }

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

        public IWebhookResponse<WebhookPerson> ParseWebhookPersonResponse(string request)
        {
            return JsonConvert.DeserializeObject<WebhookResponse<WebhookPerson>>(request);
        }
    }
}
