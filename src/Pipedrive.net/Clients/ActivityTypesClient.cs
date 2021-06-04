using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Activity Type API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/ActivityTypes">Activity Type API documentation</a> for more information.
    public class ActivityTypesClient : ApiClient, IActivityTypesClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityTypesClient"/> class.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public ActivityTypesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<ActivityType>> GetAll()
        {
            return ApiConnection.GetAll<ActivityType>(ApiUrls.ActivityTypes());
        }

        public Task<ActivityType> Create(NewActivityType data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<ActivityType>(ApiUrls.ActivityTypes(), data);
        }

        public Task<ActivityType> Edit(long id, ActivityTypeUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<ActivityType>(ApiUrls.ActivityType(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.ActivityType(id));
        }
    }
}
