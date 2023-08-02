using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Models.Request.Recents;
using Pipedrive.Models.Response.Recents;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Organization API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/Organizations">Organization API documentation</a> for more information.
    public interface IOrganizationsClient
    {
        Task<IReadOnlyList<Organization>> GetAll(OrganizationFilters filters);

        Task<IReadOnlyList<Organization>> GetAllForUserId(long userId, OrganizationFilters filters);

        Task<IReadOnlyList<SearchResult<SimpleOrganization>>> Search(string name, OrganizationSearchFilters filters);

        Task<Organization> Get(long id);

        Task<Organization> Create(NewOrganization data);

        Task<Organization> Edit(long id, OrganizationUpdate data);

        Task Delete(long id);

        Task Delete(List<long> ids);

        Task<IReadOnlyList<Deal>> GetDeals(long organizationId, OrganizationDealFilters filters);

        Task<IReadOnlyList<Person>> GetPersons(long organizationId, OrganizationFilters filters);

        Task<IReadOnlyList<OrganizationFollower>> GetFollowers(long dealId);

        Task<OrganizationFollower> AddFollower(long dealId, long userId);

        Task DeleteFollower(long dealId, long followerId);

        Task<IReadOnlyList<EntityUpdateFlow>> GetMailMessages(long organizationId, OrganizationMailMessageFilters filters);

        Task<IReadOnlyList<DealActivity>> GetActivities(long id, OrganizationActivityFilters filters);

        Task<IReadOnlyList<File>> GetFiles(long id, OrganizationFileFilters filters);

        Task<IReadOnlyList<EntityUpdateFlow>> GetUpdates(long dealId, OrganizationUpdateFilters filters);
        Task<IReadOnlyList<Recents<WebhookOrganization>>> GetRecent(RecentFilters filters);
    }
}
