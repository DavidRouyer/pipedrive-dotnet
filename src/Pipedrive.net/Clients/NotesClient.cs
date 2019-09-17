using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Note API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Notes">Note API documentation</a> for more information.
    public class NotesClient : ApiClient, INotesClient
    {
        /// <summary>
        /// Initializes a new Note API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public NotesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Note>> GetAll(NoteFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<Note>(ApiUrls.Notes(), parameters, options);
        }

        public Task<Note> Get(long id)
        {
            return ApiConnection.Get<Note>(ApiUrls.Note(id));
        }

        public Task<Note> Create(NewNote data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<Note>(ApiUrls.Notes(), data);
        }

        public Task<Note> Edit(long id, NoteUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<Note>(ApiUrls.Note(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.Note(id));
        }
    }
}
