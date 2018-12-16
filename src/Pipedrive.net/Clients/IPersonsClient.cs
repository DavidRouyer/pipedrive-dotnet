using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Person API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Persons">Person API documentation</a> for more information.
    public interface IPersonsClient
    {
        Task<IReadOnlyList<Person>> GetAll(PersonFilters filters);

        Task<IReadOnlyList<Person>> GetAllForUserId(int userId, PersonFilters filters);

        Task<IReadOnlyList<SimplePerson>> GetByName(string name);

        Task<IReadOnlyList<SimplePerson>> GetByEmail(string email);

        Task<Person> Get(long id);

        Task<Person> Create(NewPerson data);

        Task<Person> Edit(long id, PersonUpdate data);

        Task Delete(long id);

        Task<IReadOnlyList<Deal>> GetDeals(long personId, PersonDealFilters filters);
    }
}
