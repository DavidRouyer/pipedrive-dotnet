using Newtonsoft.Json;

namespace Pipedrive
{
    public class PipelineStageConversion
    {
        [JsonProperty("from_stage_id")]
        public long? FromStageId { get; set; }

        [JsonProperty("to_stage_id")]
        public long? ToStageId { get; set; }

        [JsonProperty("conversion_rate")]
        public int ConversionRate { get; set; }
    }
}
