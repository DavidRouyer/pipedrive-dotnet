using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class PipelineMovementsAverageAge
    {
        [JsonProperty("across_all_stages")]
        public decimal AcrossAllStages { get; set; }

        public IReadOnlyList<PipelineMovementsAverageAgeByStage> ByStages { get; set; }
    }
}
