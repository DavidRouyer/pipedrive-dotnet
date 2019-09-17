using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

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

        public Task<PersonField> Create(NewPersonField data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<PersonField>(ApiUrls.PersonFields(), data);
        }

        public Task<PersonField> Edit(long id, PersonFieldUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<PersonField>(ApiUrls.PersonField(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.PersonField(id));
        }
    }
}
