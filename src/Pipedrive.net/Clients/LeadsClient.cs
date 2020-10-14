using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Lead API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Leads">Lead API documentation</a> for more information.
    public class LeadsClient : ApiClient, ILeadsClient
    {
        /// <summary>
        /// Initializes a new Lead API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public LeadsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Lead>> GetAll(LeadFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Lead>(ApiUrls.Leads(), parameters, options);
        }

        public Task<Lead> Get(Guid id)
        {
            return ApiConnection.Get<Lead>(ApiUrls.Lead(id));
        }
    }
}
