using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Deal API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Deals">Deal API documentation</a> for more information.
    public interface IDealsClient
    {
        Task<IReadOnlyList<Deal>> GetAll(DealFilters filters);

        Task<IReadOnlyList<Deal>> GetAllForCurrent(DealFilters filters);

        Task<IReadOnlyList<Deal>> GetAllForUserId(long userId, DealFilters filters);

        Task<IReadOnlyList<SearchResult<SimpleDeal>>> Search(string name, DealSearchFilters filters);

        Task<Deal> Get(long id);

        Task<Deal> Create(NewDeal data);

        Task<Deal> Edit(long id, DealUpdate data);

        Task Delete(long id);

        Task Delete(List<long> ids);

        Task<DealSummary> GetSummary(DealsSummaryFilters filters);

        Task<IReadOnlyList<EntityUpdateFlow>> GetUpdates(long dealId, DealUpdateFilters filters);

        Task<IReadOnlyList<DealFollower>> GetFollowers(long dealId);

        Task<DealFollower> AddFollower(long dealId, long userId);

        Task DeleteFollower(long dealId, long followerId);

        Task<IReadOnlyList<DealActivity>> GetActivities(long dealId, DealActivityFilters filters);

        Task<IReadOnlyList<DealParticipant>> GetParticipants(long dealId, DealParticipantFilters filters);

        Task<DealParticipant> AddParticipant(long dealId, long personId);

        Task DeleteParticipant(long dealId, long dealParticipantId);

        Task<IReadOnlyList<DealProduct>> GetProducts(long dealId, DealProductFilters dealProductFilters);

        Task<CreatedDealProduct> AddProduct(long dealId, NewDealProduct newDealProduct);

        Task<UpdatedDealProduct> UpdateProduct(long dealId, long dealProductId, DealProductUpdate dealProductUpdate);

        Task DeleteProduct(long dealId, long dealProductId);
    }
}
