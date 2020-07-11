using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

namespace Pipedrive.Clients
{
    /// <summary>
    /// A client for Pipedrive's Products API
    /// </summary>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Products">Products API documentation</a> for more information
    public class ProductsClient : ApiClient, IProductsClient
    {
        /// <summary>
        /// Initializes a new Person API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public ProductsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Product>> GetAll(ProductFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Product>(ApiUrls.Products(), filters.Parameters, options);
        }

        public Task<IReadOnlyList<SearchResult<SimpleProduct>>> Search(string searchTerm, ProductSearchFilters filters)
        {
            Ensure.ArgumentNotNullOrEmptyString(searchTerm, nameof(searchTerm));
            if (searchTerm.Length < 2) throw new ArgumentException("The search term must have a minimum of 2 characters", nameof(searchTerm));

            var parameters = filters.Parameters;
            parameters.Add("term", searchTerm);
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.SearchAll<SearchResult<SimpleProduct>>(ApiUrls.ProductsSearch(), parameters, options);
        }

        public Task<Product> Get(long id)
        {
            return ApiConnection.Get<Product>(ApiUrls.Product(id));
        }

        public Task<IReadOnlyList<Deal>> GetDealsForProduct(long id)
        {
            return ApiConnection.Get<IReadOnlyList<Deal>>(ApiUrls.ProductDeals(id));
        }

        public Task<IReadOnlyList<File>> GetFilesForProduct(long id)
        {
            return ApiConnection.Get<IReadOnlyList<File>>(ApiUrls.ProductFiles(id));
        }

        public Task<IReadOnlyList<ProductFollower>> GetFollowersForProduct(long id)
        {
            return ApiConnection.Get<IReadOnlyList<ProductFollower>>(ApiUrls.ProductFollowers(id));
        }

        public Task<IReadOnlyList<long>> GetPermittedUsers(long id)
        {
            return ApiConnection.Get<IReadOnlyList<long>>(ApiUrls.ProductPermittedUsers(id));
        }

        public Task<Product> Create(NewProduct data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<Product>(ApiUrls.Products(), data);
        }

        public Task<ProductFollower> AddFollower(long id, long userId)
        {
            return ApiConnection.Post<ProductFollower>(ApiUrls.ProductFollowers(id), new { user_id = userId });
        }

        public Task<UpdatedProduct> Edit(long id, ProductUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<UpdatedProduct>(ApiUrls.Product(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.Product(id));
        }

        public Task DeleteFollower(long id, long userId)
        {
            return ApiConnection.Delete(ApiUrls.ProductDeleteFollower(id, userId));
        }
    }
}
