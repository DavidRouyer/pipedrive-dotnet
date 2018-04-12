using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Activity API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Activities">Activiy API documentation</a> for more information.
    public interface IActivitiesClient
    {
        Task<IReadOnlyList<Activity>> GetAll(ActivityFilters filters);

        Task<IReadOnlyList<Activity>> GetAllForCurrent(ActivityFilters filters);

        Task<IReadOnlyList<Activity>> GetAllForUserId(int userId, ActivityFilters filters);

        Task<Activity> Get(int id);

        Task<Activity> Create(NewActivity data);

        Task<Activity> Edit(int id, ActivityUpdate data);

        Task Delete(int id);
    }
}
