using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Recents API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Recents">Recents API documentation</a> for more information.
    public interface IRecentsClient
    {
        Task<IReadOnlyList<Recents>> GetAll(RecentsFilters filters);
    }
}
