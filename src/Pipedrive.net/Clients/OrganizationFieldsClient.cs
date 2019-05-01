using Pipedrive.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Organization Field API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/OrganizationFields">Organization Field API documentation</a> for more information.
    public class OrganizationFieldsClient : ApiClient, IOrganizationFieldsClient
    {
        /// <summary>
        /// Initializes a new Organization Field API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public OrganizationFieldsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<OrganizationField>> GetAll()
        {
            return ApiConnection.GetAll<OrganizationField>(ApiUrls.OrganizationFields());
        }

        public Task<OrganizationField> Get(long id)
        {
            return ApiConnection.Get<OrganizationField>(ApiUrls.OrganizationField(id));
        }

        public async Task<OrganizationField> Create(NewOrganizationField data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            var response = await ApiConnection.Post<JsonResponse<OrganizationField>>(ApiUrls.OrganizationFields(), data);
            return response.Data;
        }

        public async Task<OrganizationField> Edit(long id, OrganizationFieldUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            var response = await ApiConnection.Put<JsonResponse<OrganizationField>>(ApiUrls.OrganizationField(id), data);
            return response.Data;
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.OrganizationField(id));
        }
    }
}
