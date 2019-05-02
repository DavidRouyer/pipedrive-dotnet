using Pipedrive.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Organization API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Organizations">Organization API documentation</a> for more information.
    public class OrganizationsClient : ApiClient, IOrganizationsClient
    {
        /// <summary>
        /// Initializes a new Organization API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public OrganizationsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Organization>> GetAll(OrganizationFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Organization>(ApiUrls.Organizations(), parameters, options);
        }

        public Task<IReadOnlyList<Organization>> GetAllForUserId(int userId, OrganizationFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("user_id", userId.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Organization>(ApiUrls.Organizations(), parameters, options);
        }

        public Task<IReadOnlyList<SimpleOrganization>> GetByName(string name)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("term", name);

            return ApiConnection.GetAll<SimpleOrganization>(ApiUrls.OrganizationsFind(), parameters);
        }

        public Task<Organization> Get(long id)
        {
            return ApiConnection.Get<Organization>(ApiUrls.Organization(id));
        }

        public Task<Organization> Create(NewOrganization data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<Organization>(ApiUrls.Organizations(), data);
        }

        public Task<Organization> Edit(long id, OrganizationUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<Organization>(ApiUrls.Organization(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.Organization(id));
        }

        public Task<IReadOnlyList<Deal>> GetDeals(long personId, OrganizationDealFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", personId.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Deal>(ApiUrls.OrganizationDeal(personId), parameters, options);
        }
    }
}
