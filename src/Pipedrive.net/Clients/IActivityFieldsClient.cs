using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Activity Field API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/ActivityFields">Activiy Field API documentation</a> for more information.
    public interface IActivityFieldsClient
    {
        Task<IReadOnlyList<ActivityField>> GetAll(ApiOptions options);
    }
}
