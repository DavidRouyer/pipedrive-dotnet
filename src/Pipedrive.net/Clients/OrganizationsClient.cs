using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

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

        public Task<IReadOnlyList<Organization>> GetAllForUserId(long userId, OrganizationFilters filters)
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

        public Task<IReadOnlyList<SearchResult<SimpleOrganization>>> Search(string term, OrganizationSearchFilters filters)
        {
            Ensure.ArgumentNotNull(term, nameof(term));
            Ensure.ArgumentNotNull(filters, nameof(filters));
            if (filters.ExactMatch.HasValue && filters.ExactMatch.Value == true)
            {
                if (term.Length < 1) throw new ArgumentException("The search term must have at least 1 character", nameof(term));
            }
            else
            {
                if (term.Length < 2) throw new ArgumentException("The search term must have at least 2 characters", nameof(term));
            }

            var parameters = filters.Parameters;
            parameters.Add("term", term);
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.SearchAll<SearchResult<SimpleOrganization>>(ApiUrls.OrganizationsSearch(), parameters, options);
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

        public Task<IReadOnlyList<Deal>> GetDeals(long id, OrganizationDealFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", id.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Deal>(ApiUrls.OrganizationDeal(id), parameters, options);
        }

        public Task<IReadOnlyList<Person>> GetPersons(long id, OrganizationFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));
            var parameters = filters.Parameters;
            parameters.Add("id", id.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Person>(ApiUrls.OrganizationPersons(id), parameters, options);
        }

        public Task<IReadOnlyList<OrganizationFollower>> GetFollowers(long personId)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "id", personId.ToString() }
            };

            return ApiConnection.GetAll<OrganizationFollower>(ApiUrls.OrganizationFollowers(personId), parameters);
        }

        public Task<OrganizationFollower> AddFollower(long personId, long userId)
        {
            return ApiConnection.Post<OrganizationFollower>(ApiUrls.OrganizationFollowers(personId), new
            {
                user_id = userId
            });
        }

        public Task DeleteFollower(long dealId, long followerId)
        {
            return ApiConnection.Delete(ApiUrls.DeleteOrganizationFollower(dealId, followerId));
        }

        public Task<IReadOnlyList<DealActivity>> GetActivities(long id, OrganizationActivityFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", id.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<DealActivity>(ApiUrls.OrganizationActivities(id), parameters, options);
        }

        public Task<IReadOnlyList<DealUpdateFlow>> GetUpdates(long dealId, OrganizationUpdateFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", dealId.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<DealUpdateFlow>(ApiUrls.OrganizationUpdates(dealId), parameters, options);
        }
    }
}
