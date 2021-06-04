using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Deal API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Deals">Deal API documentation</a> for more information.
    public class DealsClient : ApiClient, IDealsClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DealsClient"/> class.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public DealsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Deal>> GetAll(DealFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("owned_by_you", "0");
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Deal>(ApiUrls.Deals(), parameters, options);
        }

        public Task<IReadOnlyList<Deal>> GetAllForCurrent(DealFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("owned_by_you", "1");
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Deal>(ApiUrls.Deals(), parameters, options);
        }

        public Task<IReadOnlyList<Deal>> GetAllForUserId(long userId, DealFilters filters)
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

            return ApiConnection.GetAll<Deal>(ApiUrls.Deals(), parameters, options);
        }

        public Task<IReadOnlyList<SearchResult<SimpleDeal>>> Search(string term, DealSearchFilters filters)
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

            return ApiConnection.SearchAll<SearchResult<SimpleDeal>>(ApiUrls.DealsSearch(), parameters, options);
        }

        public Task<Deal> Get(long id)
        {
            return ApiConnection.Get<Deal>(ApiUrls.Deal(id));
        }

        public Task<Deal> Create(NewDeal data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<Deal>(ApiUrls.Deals(), data);
        }

        public Task<Deal> Edit(long id, DealUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<Deal>(ApiUrls.Deal(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.Deal(id));
        }

        public Task Delete(List<long> ids)
        {
            Ensure.ArgumentNotNull(ids, nameof(ids));
            Ensure.GreaterThanZero(ids.Count, nameof(ids));

            return ApiConnection.Delete(new Uri($"{ApiUrls.Deals()}?ids={string.Join(",", ids)}", UriKind.Relative));
        }

        public Task<IReadOnlyList<EntityUpdateFlow>> GetUpdates(long dealId, DealUpdateFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", dealId.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<EntityUpdateFlow>(ApiUrls.DealUpdates(dealId), parameters, options);
        }

        public Task<IReadOnlyList<DealFollower>> GetFollowers(long dealId)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "id", dealId.ToString() }
            };

            return ApiConnection.GetAll<DealFollower>(ApiUrls.DealFollowers(dealId), parameters);
        }

        public Task<DealFollower> AddFollower(long dealId, long userId)
        {
            return ApiConnection.Post<DealFollower>(ApiUrls.DealFollowers(dealId), new
            {
                user_id = userId
            });
        }

        public Task DeleteFollower(long dealId, long followerId)
        {
            return ApiConnection.Delete(ApiUrls.DeleteDealFollower(dealId, followerId));
        }

        public Task<IReadOnlyList<DealActivity>> GetActivities(long dealId, DealActivityFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", dealId.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<DealActivity>(ApiUrls.DealActivities(dealId), parameters, options);
        }

        public Task<IReadOnlyList<DealParticipant>> GetParticipants(long dealId, DealParticipantFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", dealId.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<DealParticipant>(ApiUrls.DealParticipants(dealId), parameters, options);
        }

        public Task<DealParticipant> AddParticipant(long dealId, long personId)
        {
            return ApiConnection.Post<DealParticipant>(ApiUrls.DealParticipants(dealId), new
            {
                person_id = personId
            });
        }

        public Task DeleteParticipant(long dealId, long dealParticipantId)
        {
            return ApiConnection.Delete(ApiUrls.DeleteDealParticipant(dealId, dealParticipantId));
        }

        public Task<IReadOnlyList<DealProduct>> GetProductsForDeal(long dealId, DealProductFilters dealProductFilters)
        {
            Ensure.ArgumentNotNull(dealProductFilters, nameof(dealProductFilters));

            var options = new ApiOptions
            {
                StartPage = dealProductFilters.StartPage,
                PageCount = dealProductFilters.PageCount,
                PageSize = dealProductFilters.PageSize
            };

            return ApiConnection.GetAll<DealProduct>(ApiUrls.DealProducts(dealId), dealProductFilters.Parameters, options);
        }

        public Task<CreatedDealProduct> AddProductToDeal(long dealId, NewDealProduct newDealProduct)
        {
            Ensure.ArgumentNotNull(newDealProduct, nameof(newDealProduct));

            return ApiConnection.Post<CreatedDealProduct>(ApiUrls.AddProductToDeal(dealId), newDealProduct);
        }

        public Task<UpdatedDealProduct> UpdateDealProduct(long dealId, long dealProductId, DealProductUpdate dealProductUpdate)
        {
            Ensure.ArgumentNotNull(dealProductUpdate, nameof(dealProductUpdate));
            return ApiConnection.Put<UpdatedDealProduct>(ApiUrls.UpdateDealProduct(dealId, dealProductId), dealProductUpdate);
        }

        public Task DeleteDealProduct(long dealId, long dealProductId)
        {
            return ApiConnection.Delete(ApiUrls.DeleteDealProduct(dealId, dealProductId));
        }
    }
}
