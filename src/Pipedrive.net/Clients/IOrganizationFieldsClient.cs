using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Organization Field API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/OrganizationFields">Organization Field API documentation</a> for more information.
    public interface IOrganizationFieldsClient
    {
        Task<IReadOnlyList<OrganizationField>> GetAll();

        Task<OrganizationField> Get(long id);

        Task<OrganizationField> Create(NewOrganizationField data);

        Task<OrganizationField> Edit(long id, OrganizationFieldUpdate data);

        Task Delete(long id);

        Task Delete(List<long> ids);
    }
}
