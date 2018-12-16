using Pipedrive.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Stage API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Stages">Stage API documentation</a> for more information.
    public class StagesClient : ApiClient, IStagesClient
    {
        /// <summary>
        /// Initializes a new Stage API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public StagesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Stage>> GetAll()
        {
            return ApiConnection.GetAll<Stage>(ApiUrls.Stages());
        }

        public Task<IReadOnlyList<Stage>> GetAllForPipelineId(long pipelineId)
        {
            var parameters = new Dictionary<string, string>()
            {
                { "pipeline_id", pipelineId.ToString() }
            };

            return ApiConnection.GetAll<Stage>(ApiUrls.Stages(), parameters);
        }

        public Task<Stage> Get(long id)
        {
            return ApiConnection.Get<Stage>(ApiUrls.Stage(id));
        }

        public Task<Stage> Create(NewStage data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<Stage>(ApiUrls.Stages(), data);
        }

        public Task<Stage> Edit(long id, StageUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<Stage>(ApiUrls.Stage(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.Stage(id));
        }

        public Task<IReadOnlyList<PipelineDeal>> GetDeals(long stageId, StageDealFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", stageId.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<PipelineDeal>(ApiUrls.StageDeal(stageId), parameters, options);
        }
    }
}
