using Pipedrive.Helpers;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's File API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Files">File API documentation</a> for more information.
    public class FilesClient : ApiClient, IFilesClient
    {
        /// <summary>
        /// Initializes a new File API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public FilesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<File>> GetAll(FileFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<File>(ApiUrls.Files(), parameters, options);
        }

        public Task<File> Get(long id)
        {
            return ApiConnection.Get<File>(ApiUrls.File(id));
        }

        /*public async Task<File> Create(NewFile data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(data.File), "\"file\"");

            if (data.DealId.HasValue)
            {
                content.Add(new StringContent(data.DealId.ToString()), "deal_id");
            }
            if (data.PersonId.HasValue)
            {
                content.Add(new StringContent(data.PersonId.ToString()), "person_id");
            }
            if (data.OrgId.HasValue)
            {
                content.Add(new StringContent(data.OrgId.ToString()), "org_id");
            }
            if (data.ProductId.HasValue)
            {
                content.Add(new StringContent(data.ProductId.ToString()), "product_id");
            }
            if (data.ActivityId.HasValue)
            {
                content.Add(new StringContent(data.ActivityId.ToString()), "activity_id");
            }
            if (data.NoteId.HasValue)
            {
                content.Add(new StringContent(data.NoteId.ToString()), "note_id");
            }
            var contentString = content.ReadAsStringAsync();

            return await ApiConnection.Post<File>(ApiUrls.Files(), content, "application/json", "multipart/form-data");
        }*/

        public Task<File> Edit(long id, FileUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<File>(ApiUrls.File(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.File(id));
        }
    }
}
