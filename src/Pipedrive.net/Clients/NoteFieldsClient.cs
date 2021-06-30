using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Note Field API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/NoteFields">Note Field API documentation</a> for more information.
    public class NoteFieldsClient : ApiClient, INoteFieldsClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoteFieldsClient"/> class.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public NoteFieldsClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<NoteField>> GetAll()
        {
            return ApiConnection.GetAll<NoteField>(ApiUrls.NoteFields());
        }
    }
}
