using Pipedrive.Clients;
using Pipedrive.Helpers;
using System;
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

            return ApiConnection.GetAll<Recents>(ApiUrls.Recents(), parameters,options);
        }
        public Task<IReadOnlyList<Recents>> GetDealRecents(DateTime sinceWhen)
        {
            var parameters = new Dictionary<string, string>
            {
                { "since_timestamp", sinceWhen.ToString("yyyy-MM-dd HH:mm:ss") },
                { "items", "deal" }
            };

            return ApiConnection.GetAll<Recents>(ApiUrls.Recents(), parameters);
        }
        public Task<IReadOnlyList<Recents>> GetActivityRecents(DateTime sinceWhen)
        {
            var parameters = new Dictionary<string, string>
            {
                { "since_timestamp", sinceWhen.ToString("yyyy-MM-dd HH:mm:ss") },
                { "items", "activity" }
            };

            return ApiConnection.GetAll<Recents>(ApiUrls.Recents(), parameters);
        }
    }
}
