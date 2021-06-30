using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Product Field API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/ProductFields">Product Field API documentation</a> for more information.
    public interface IProductFieldsClient
    {
        Task<IReadOnlyList<ProductField>> GetAll();

        Task<ProductField> Get(long id);

        Task<ProductField> Create(NewProductField data);

        Task<ProductField> Edit(long id, ProductFieldUpdate data);

        Task Delete(long id);

        Task Delete(List<long> ids);
    }
}
