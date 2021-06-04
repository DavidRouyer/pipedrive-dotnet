using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Activity API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Activities">Activity API documentation</a> for more information.
    public interface IActivitiesClient
    {
        Task<IReadOnlyList<Activity>> GetAll(ActivityFilters filters);

        Task<IReadOnlyList<Activity>> GetAllForCurrent(ActivityFilters filters);

        Task<IReadOnlyList<Activity>> GetAllForUserId(long userId, ActivityFilters filters);

        Task<Activity> Get(long id);

        Task<Activity> Create(NewActivity data);

        Task<Activity> Edit(long id, ActivityUpdate data);

        Task Delete(long id);

        Task Delete(List<long> ids);
    }
}
