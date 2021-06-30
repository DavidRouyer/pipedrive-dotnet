using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Currency API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/Currencies">Currency API documentation</a> for more information.
    public interface ICurrenciesClient
    {
        Task<IReadOnlyList<Currency>> GetAll();

        Task<IReadOnlyList<Currency>> GetAll(string term);
    }
}
