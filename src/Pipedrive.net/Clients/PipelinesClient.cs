using Pipedrive.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Pipeline API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Pipelines">Pipeline API documentation</a> for more information.
    public class PipelinesClient : ApiClient, IPipelinesClient
    {
        /// <summary>
        /// Initializes a new Pipeline API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public PipelinesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Pipeline>> GetAll()
        {
            return ApiConnection.GetAll<Pipeline>(ApiUrls.Pipelines());
        }

        public Task<Pipeline> Get(long id)
        {
            return ApiConnection.Get<Pipeline>(ApiUrls.Pipeline(id));
        }

        public Task<Pipeline> Create(NewPipeline data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Post<Pipeline>(ApiUrls.Pipelines(), data);
        }

        public Task<Pipeline> Edit(long id, PipelineUpdate data)
        {
            Ensure.ArgumentNotNull(data, nameof(data));

            return ApiConnection.Put<Pipeline>(ApiUrls.Pipeline(id), data);
        }

        public Task Delete(long id)
        {
            return ApiConnection.Delete(ApiUrls.Pipeline(id));
        }

        public Task<IReadOnlyList<PipelineDeal>> GetDeals(long pipelineId, PipelineDealFilters filters)
        {
            Ensure.ArgumentNotNull(filters, nameof(filters));

            var parameters = filters.Parameters;
            parameters.Add("id", pipelineId.ToString());
            var options = new ApiOptions
            {
                StartPage = filters.StartPage,
                PageCount = filters.PageCount,
                PageSize = filters.PageSize
            };

            return ApiConnection.GetAll<PipelineDeal>(ApiUrls.PipelineDeal(pipelineId), parameters, options);
        }
    }
}
