using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

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
        /// Initializes a new instance of the <see cref="OrganizationFieldsClient"/> class.
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

        public Task<OrganizationField> Create(NewOrganizationField data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<OrganizationField>(ApiUrls.OrganizationFields(), data);
        }

        public Task<OrganizationField> Edit(long id, OrganizationFieldUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<OrganizationField>(ApiUrls.OrganizationField(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.OrganizationField(id));
        }

        public Task Delete(List<long> ids)
        {
            Ensure.ArgumentNotNull(ids, nameof(ids));
            Ensure.GreaterThanZero(ids.Count, nameof(ids));

            return ApiConnection.Delete(new Uri($"{ApiUrls.OrganizationFields()}?ids={string.Join(",", ids)}", UriKind.Relative));
        }
    }
}
