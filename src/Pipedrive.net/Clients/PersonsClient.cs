using Pipedrive.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Person API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Persons">Person API documentation</a> for more information.
    public class PersonsClient : ApiClient, IPersonsClient
    {
        /// <summary>
        /// Initializes a new Person API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public PersonsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Person>> GetAll(PersonFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Person>(ApiUrls.Persons(), parameters, options);
        }

        public Task<IReadOnlyList<Person>> GetAllForUserId(int userId, PersonFilters filters)
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

            return ApiConnection.GetAll<Person>(ApiUrls.Persons(), parameters, options);
        }

        public Task<IReadOnlyList<SimplePerson>> GetByName(string name)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("term", name);
            parameters.Add("search_by_email", "0");

            return ApiConnection.GetAll<SimplePerson>(ApiUrls.PersonsFind(), parameters);
        }

        public Task<IReadOnlyList<SimplePerson>> GetByEmail(string email)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("term", email);
            parameters.Add("search_by_email", "1");

            return ApiConnection.GetAll<SimplePerson>(ApiUrls.PersonsFind(), parameters);
        }

        public Task<Person> Get(long id)
        {
            return ApiConnection.Get<Person>(ApiUrls.Person(id));
        }

        public Task<Person> Create(NewPerson data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<Person>(ApiUrls.Persons(), data);
        }

        public Task<Person> Edit(long id, PersonUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<Person>(ApiUrls.Person(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.Person(id));
        }

        public Task<IReadOnlyList<Deal>> GetDeals(long personId, PersonDealFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", personId.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Deal>(ApiUrls.PersonDeal(personId), parameters, options);
        }
    }
}
