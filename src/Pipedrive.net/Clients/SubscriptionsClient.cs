using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Subscription API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/Subscriptions">Subscription API documentation</a> for more information.
    public class SubscriptionsClient : ApiClient, ISubscriptionsClient
    {
        /// <summary>
        /// Initializes a new Subscription API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public SubscriptionsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Subscription>> GetAllForDealId(long dealId)
        {
            return ApiConnection.GetAll<Subscription>(ApiUrls.SubscriptionsByDealId(dealId));
        }

        public Task<Subscription> Get(long id)
        {
            return ApiConnection.Get<Subscription>(ApiUrls.Subscription(id));
        }

        public Task<Subscription> CreateRecurring(NewRecurringSubscription data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<Subscription>(ApiUrls.SubscriptionRecurring(), data);
        }

        public Task<Subscription> CreateInstallment(NewInstallmentSubscription data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<Subscription>(ApiUrls.SubscriptionInstallment(), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.Subscription(id));
        }
    }
}
