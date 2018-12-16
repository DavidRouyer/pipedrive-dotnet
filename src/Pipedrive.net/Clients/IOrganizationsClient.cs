using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Organization API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Organizations">Organization API documentation</a> for more information.
    public interface IOrganizationsClient
    {
        Task<IReadOnlyList<Organization>> GetAll(OrganizationFilters filters);

        Task<IReadOnlyList<Organization>> GetAllForUserId(int userId, OrganizationFilters filters);

        Task<IReadOnlyList<SimpleOrganization>> GetByName(string name);

        Task<Organization> Get(long id);

        Task<Organization> Create(NewOrganization data);

        Task<Organization> Edit(long id, OrganizationUpdate data);

        Task Delete(long id);

        Task<IReadOnlyList<Deal>> GetDeals(long organizationId, OrganizationDealFilters filters);
    }
}
