using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Filter API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/Filters">Filter API documentation</a> for more information.
    public class FiltersClient : ApiClient, IFiltersClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FiltersClient"/> class.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public FiltersClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Filter>> GetAll(FilterFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;

            return ApiConnection.GetAll<Filter>(ApiUrls.Filters(), parameters);
        }

        public Task<Filter> Get(long id)
        {
            return ApiConnection.Get<Filter>(ApiUrls.Filter(id));
        }
    }
}
