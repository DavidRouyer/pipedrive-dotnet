using Pipedrive.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's User API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Users">User API documentation</a> for more information.
    public class UsersClient : ApiClient, IUsersClient
    {
        /// <summary>
        /// Initializes a new User API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public UsersClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<User>> GetAll()
        {
            return ApiConnection.GetAll<User>(ApiUrls.Users());
        }

        public Task<IReadOnlyList<User>> GetByName(string name)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("term", name);
            parameters.Add("search_by_email", "0");

            return ApiConnection.GetAll<User>(ApiUrls.UsersFind(), parameters);
        }

        public Task<IReadOnlyList<User>> GetByEmail(string email)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("term", email);
            parameters.Add("search_by_email", "1");

            return ApiConnection.GetAll<User>(ApiUrls.UsersFind(), parameters);
        }

        public Task<User> Get(long id)
        {
            return ApiConnection.Get<User>(ApiUrls.User(id));
        }

        public Task<User> Create(NewUser data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<User>(ApiUrls.Users(), data);
        }

        public Task<User> Edit(long id, UserUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<User>(ApiUrls.User(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.User(id));
        }

        public Task<User> Me()
        {
            return ApiConnection.Get<User>(ApiUrls.UsersMe());
        }
    }
}
