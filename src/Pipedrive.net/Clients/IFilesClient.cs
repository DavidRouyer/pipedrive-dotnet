using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's File API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Files">File API documentation</a> for more information.
    public interface IFilesClient
    {
        Task<IReadOnlyList<File>> GetAll(FileFilters filters);

        Task<File> Get(long id);

        Task<File> Create(NewFile data);

        Task<File> Edit(long id, FileUpdate data);

        Task Delete(long id);
    }
}
