﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;
using Pipedrive.Models.Request.Recents;
using Pipedrive.Models.Response.Recents;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Person API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/Persons">Person API documentation</a> for more information.
    public class PersonsClient : ApiClient, IPersonsClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonsClient"/> class.
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

        public Task<IReadOnlyList<Person>> GetAllForUserId(long userId, PersonFilters filters)
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

        public Task<IReadOnlyList<SearchResult<SimplePerson>>> Search(string term, PersonSearchFilters filters)
        {
            Ensure.ArgumentNotNull(term, nameof(term));
            Ensure.ArgumentNotNull(filters, nameof(filters));
            if (filters.ExactMatch.HasValue && filters.ExactMatch.Value == true)
            {
                if (term.Length < 1) throw new ArgumentException("The search term must have at least 1 character", nameof(term));
            }
            else
            {
                if (term.Length < 2) throw new ArgumentException("The search term must have at least 2 characters", nameof(term));
            }

            var parameters = filters.Parameters;
            parameters.Add("term", term);
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.SearchAll<SearchResult<SimplePerson>>(ApiUrls.PersonsSearch(), parameters, options);
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

        public Task Delete(List<long> ids)
        {
            Ensure.ArgumentNotNull(ids, nameof(ids));
            Ensure.GreaterThanZero(ids.Count, nameof(ids));

            return ApiConnection.Delete(new Uri($"{ApiUrls.Persons()}?ids={string.Join(",", ids)}", UriKind.Relative));
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

            return ApiConnection.GetAll<Deal>(ApiUrls.PersonDeals(personId), parameters, options);
        }

        public Task<IReadOnlyList<Activity>> GetActivities(long personId, PersonActivityFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", personId.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Activity>(ApiUrls.PersonActivities(personId), parameters, options);
        }

        public Task<IReadOnlyList<File>> GetFiles(long personId, PersonFileFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", personId.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<File>(ApiUrls.PersonFiles(personId), parameters, options);
        }

        public Task<IReadOnlyList<EntityUpdateFlow>> GetUpdates(long id, PersonUpdateFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", id.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<EntityUpdateFlow>(ApiUrls.PersonUpdates(id), parameters, options);
        }

        public Task<IReadOnlyList<PersonFollower>> GetFollowers(long personId)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "id", personId.ToString() }
            };

            return ApiConnection.GetAll<PersonFollower>(ApiUrls.PersonFollowers(personId), parameters);
        }

        public Task<PersonFollower> AddFollower(long personId, long userId)
        {
            return ApiConnection.Post<PersonFollower>(ApiUrls.PersonFollowers(personId), new
            {
                user_id = userId
            });
        }

        public Task DeleteFollower(long dealId, long followerId)
        {
            return ApiConnection.Delete(ApiUrls.DeletePersonFollower(dealId, followerId));
        }

        public Task<IReadOnlyList<EntityUpdateFlow>> GetMailMessages(long personId, PersonMailMessageFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<EntityUpdateFlow>(ApiUrls.PersonMailMessages(personId), parameters, options);
        }

        public Task<IReadOnlyList<Recents<WebhookPerson>>> GetRecent(RecentFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));
            filters.RecentItems = new List<RecentItem> { RecentItem.person };
            var parameters = filters.Parameters;
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Recents<WebhookPerson>>(ApiUrls.Recents(), parameters, options);
        }
    }
}
