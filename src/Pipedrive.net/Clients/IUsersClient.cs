using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's User API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Users">User API documentation</a> for more information.
    public interface IUsersClient
    {
        Task<IReadOnlyList<User>> GetAll();

        Task<IReadOnlyList<User>> GetByName(string name);

        Task<IReadOnlyList<User>> GetByEmail(string email);

        Task<User> Get(long id);

        Task<User> Create(NewUser data);

        Task<User> Edit(long id, UserUpdate data);

        Task Delete(long id);

        Task<User> Me();
    }
}
