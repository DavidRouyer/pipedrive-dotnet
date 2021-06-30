using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Filter API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/Filters">Filter API documentation</a> for more information.
    public interface IFiltersClient
    {
        Task<IReadOnlyList<Filter>> GetAll(FilterFilters filters);

        Task<Filter> Get(long id);
    }
}
