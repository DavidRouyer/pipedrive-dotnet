﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;
using Pipedrive.Models.Request;
using Pipedrive.Models.Response;

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
        /// Initializes a new Deal API client.
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

        public Task<IReadOnlyList<Deal>> GetAllForUserId(int userId, DealFilters filters)
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

        public Task<IReadOnlyList<SimpleDeal>> GetByName(string name)
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("term", name);

            return ApiConnection.GetAll<SimpleDeal>(ApiUrls.DealsFind(), parameters);
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

        public Task<IReadOnlyList<DealUpdateFlow>> GetUpdates(long dealId, DealUpdateFilters filters)
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

            return ApiConnection.GetAll<DealUpdateFlow>(ApiUrls.DealUpdates(dealId), parameters, options);
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
