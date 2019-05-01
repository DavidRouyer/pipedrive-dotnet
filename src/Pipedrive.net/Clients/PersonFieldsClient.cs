using Pipedrive.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Person Field API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/PersonFields">Person Field API documentation</a> for more information.
    public class PersonFieldsClient : ApiClient, IPersonFieldsClient
    {
        /// <summary>
        /// Initializes a new Person Field API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public PersonFieldsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<PersonField>> GetAll()
        {
            return ApiConnection.GetAll<PersonField>(ApiUrls.PersonFields());
        }

        public Task<PersonField> Get(long id)
        {
            return ApiConnection.Get<PersonField>(ApiUrls.PersonField(id));
        }

        public async Task<PersonField> Create(NewPersonField data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            var response = await ApiConnection.Post<JsonResponse<PersonField>>(ApiUrls.PersonFields(), data);
            return response.Data;
        }

        public async Task<PersonField> Edit(long id, PersonFieldUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            var response = await ApiConnection.Put<JsonResponse<PersonField>>(ApiUrls.PersonField(id), data);
            return response.Data;
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.PersonField(id));
        }
    }
}
