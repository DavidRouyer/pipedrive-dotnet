using Pipedrive.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Activity Type API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/ActivityTypes">Activiy Type API documentation</a> for more information.
    public class ActivityTypesClient : ApiClient, IActivityTypesClient
    {
        /// <summary>
        /// Initializes a new Activity Type API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public ActivityTypesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<ActivityType>> GetAll()
        {
            return ApiConnection.GetAll<ActivityType>(ApiUrls.ActivityTypes());
        }
    }
}
