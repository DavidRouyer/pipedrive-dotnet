using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Person Field API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/PersonFields">Person Field API documentation</a> for more information.
    public interface IPersonFieldsClient
    {
        Task<IReadOnlyList<PersonField>> GetAll();

        Task<PersonField> Get(long id);

        Task<PersonField> Create(NewPersonField data);

        Task<PersonField> Edit(long id, PersonFieldUpdate data);

        Task Delete(long id);
    }
}
