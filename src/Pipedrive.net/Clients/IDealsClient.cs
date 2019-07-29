using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Models.Response;

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

        Task<IReadOnlyList<Deal>> GetAllForUserId(int userId, DealFilters filters);

        Task<IReadOnlyList<SimpleDeal>> GetByName(string name);

        Task<Deal> Get(long id);

        Task<Deal> Create(NewDeal data);

        Task<Deal> Edit(long id, DealUpdate data);

        Task Delete(long id);

        Task<IReadOnlyList<DealUpdateFlow>> GetUpdates(long dealId, DealUpdateFilters filters);

        Task<IReadOnlyList<Follower>> GetFollowers(long dealId);

        Task<Follower> AddFollower(long dealId, long userId);

        Task DeleteFollower(long dealId, long followerId);

        Task<IReadOnlyList<DealActivity>> GetActivities(long dealId, DealActivityFilters filters);

        Task<IReadOnlyList<DealParticipant>> GetParticipants(long dealId, DealParticipantFilters filters);

        Task<DealParticipant> AddParticipant(long dealId, long personId);

        Task DeleteParticipant(long dealId, long dealParticipantId);
    }
}
