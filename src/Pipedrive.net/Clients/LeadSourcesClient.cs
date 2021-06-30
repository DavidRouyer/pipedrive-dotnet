using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Lead Source API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/LeadSources">Lead Source API documentation</a> for more information.
    public class LeadSourcesClient : ApiClient, ILeadSourcesClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LeadSourcesClient"/> class.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public LeadSourcesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<LeadSource>> GetAll()
        {
            return ApiConnection.GetAll<LeadSource>(ApiUrls.LeadSources());
        }
    }
}
