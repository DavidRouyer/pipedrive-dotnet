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

        Task<IReadOnlyList<Person>> GetAllForUserId(long userId, PersonFilters filters);

        Task<IReadOnlyList<SearchResult<SimplePerson>>> Search(string name, PersonSearchFilters filters);

        Task<Person> Get(long id);

        Task<Person> Create(NewPerson data);

        Task<Person> Edit(long id, PersonUpdate data);

        Task Delete(long id);

        Task<IReadOnlyList<Deal>> GetDeals(long personId, PersonDealFilters filters);

        Task<IReadOnlyList<PersonFollower>> GetFollowers(long dealId);

        Task<PersonFollower> AddFollower(long dealId, long userId);

        Task DeleteFollower(long dealId, long followerId);
    }
}
