using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Activity Field API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/ActivityFields">Activity Field API documentation</a> for more information.
    public class ActivityFieldsClient : ApiClient, IActivityFieldsClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityFieldsClient"/> class.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public ActivityFieldsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<ActivityField>> GetAll(ApiOptions options)
        {
            Ensure.ArgumentNotNull(options, nameof(options));

            return ApiConnection.GetAll<ActivityField>(ApiUrls.ActivityFields(), options);
        }
    }
}
