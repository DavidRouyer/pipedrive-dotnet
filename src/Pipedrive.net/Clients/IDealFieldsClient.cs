using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Deal Field API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/DealFields">Deal Field API documentation</a> for more information.
    public interface IDealFieldsClient
    {
        Task<IReadOnlyList<DealField>> GetAll();

        Task<DealField> Get(int id);

        Task<DealField> Create(NewDealField data);

        Task<DealField> Edit(int id, DealFieldUpdate data);

        Task Delete(int id);
    }
}
