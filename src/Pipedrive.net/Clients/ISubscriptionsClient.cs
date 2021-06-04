using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Subscription API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/Subscriptions">Subscription API documentation</a> for more information.
    public interface ISubscriptionsClient
    {
        Task<Subscription> GetByDealId(long dealId);

        Task<Subscription> Get(long id);

        Task<IReadOnlyList<Payment>> GetPayments(long id);

        Task<Subscription> CreateRecurring(NewRecurringSubscription data);

        Task<Subscription> CreateInstallment(NewInstallmentSubscription data);

        Task<Subscription> CancelRecurring(long id, CancelRecurringSubscription data);

        Task Delete(long id);
    }
}
