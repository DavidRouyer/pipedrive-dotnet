using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Stage API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Stages">Stage API documentation</a> for more information.
    public interface IStagesClient
    {
        Task<IReadOnlyList<Stage>> GetAll();

        Task<IReadOnlyList<Stage>> GetAllForPipelineId(long pipelineId);

        Task<Stage> Get(long id);

        Task<Stage> Create(NewStage data);

        Task<Stage> Edit(long id, StageUpdate data);

        Task Delete(long id);

        Task<IReadOnlyList<PipelineDeal>> GetDeals(long stageId, StageDealFilters filters);
    }
}
