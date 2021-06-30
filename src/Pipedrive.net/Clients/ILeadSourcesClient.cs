using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Lead Source API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/LeadSources">Lead Source API documentation</a> for more information.
    public interface ILeadSourcesClient
    {
        Task<IReadOnlyList<LeadSource>> GetAll();
    }
}
