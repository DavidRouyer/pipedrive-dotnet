using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class PipelineConversionStatistic
    {
        [JsonProperty("stage_conversions")]
        public IReadOnlyList<PipelineStageConversion> StageConversions { get; set; }

        [JsonProperty("won_conversion")]
        public int WonConversion { get; set; }

        [JsonProperty("lost_conversion")]
        public int LostConversion { get; set; }
    }
}
