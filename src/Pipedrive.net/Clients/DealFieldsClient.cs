using Pipedrive.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Deal Field API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/DealFields">Deal Field API documentation</a> for more information.
    public class DealFieldsClient : ApiClient, IDealFieldsClient
    {
        /// <summary>
        /// Initializes a new Activity Field API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public DealFieldsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<DealField>> GetAll()
        {
            return ApiConnection.GetAll<DealField>(ApiUrls.DealFields());
        }

        public Task<DealField> Get(long id)
        {
            return ApiConnection.Get<DealField>(ApiUrls.DealField(id));
        }

        public Task<DealField> Create(NewDealField data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<DealField>(ApiUrls.DealFields(), data);
        }

        public Task<DealField> Edit(long id, DealFieldUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<DealField>(ApiUrls.DealField(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.DealField(id));
        }
    }
}
