using Pipedrive.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Stage API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Stages">Stages API documentation</a> for more information.
    public class RecentsClient : ApiClient, IRecentsClient
    {
        /// <summary>
        /// Initializes a new Recents API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public RecentsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Recents>> GetAll(RecentsFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;

            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Recents>(ApiUrls.Recents(), parameters, options);
        }
    }
}
