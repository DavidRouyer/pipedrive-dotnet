using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive.Clients
{
    /// <summary>
    /// A client for Pipedrive's Products API
    /// </summary>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/Products">Products API documentation</a> for more information
    public interface IProductsClient
    {
        Task<IReadOnlyList<Product>> GetAll(ProductFilters filters);

        Task<IReadOnlyList<SearchResult<SimpleProduct>>> Search(string searchTerm, ProductSearchFilters filters);

        Task<Product> Get(long id);

        Task<IReadOnlyList<Deal>> GetDealsForProduct(long id);

        Task<IReadOnlyList<File>> GetFilesForProduct(long id);

        Task<IReadOnlyList<ProductFollower>> GetFollowersForProduct(long id);

        Task<IReadOnlyList<long>> GetPermittedUsers(long id);

        Task<Product> Create(NewProduct data);

        Task<ProductFollower> AddFollower(long id, long userId);

        Task<UpdatedProduct> Edit(long id, ProductUpdate data);

        Task Delete(long id);

        Task DeleteFollower(long id, long userId);
    }
}
