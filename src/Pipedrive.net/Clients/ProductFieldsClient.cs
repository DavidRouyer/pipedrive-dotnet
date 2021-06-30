using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Product Field API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/ProductFields">Product Field API documentation</a> for more information.
    public class ProductFieldsClient : ApiClient, IProductFieldsClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductFieldsClient"/> class.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public ProductFieldsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<ProductField>> GetAll()
        {
            return ApiConnection.GetAll<ProductField>(ApiUrls.ProductFields());
        }

        public Task<ProductField> Get(long id)
        {
            return ApiConnection.Get<ProductField>(ApiUrls.ProductField(id));
        }

        public Task<ProductField> Create(NewProductField data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<ProductField>(ApiUrls.ProductFields(), data);
        }

        public Task<ProductField> Edit(long id, ProductFieldUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<ProductField>(ApiUrls.ProductField(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.ProductField(id));
        }

        public Task Delete(List<long> ids)
        {
            Ensure.ArgumentNotNull(ids, nameof(ids));
            Ensure.GreaterThanZero(ids.Count, nameof(ids));

            return ApiConnection.Delete(new Uri($"{ApiUrls.ProductFields()}?ids={string.Join(",", ids)}", UriKind.Relative));
        }
    }
}
