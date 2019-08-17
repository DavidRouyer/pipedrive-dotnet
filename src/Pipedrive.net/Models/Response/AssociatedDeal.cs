using Newtonsoft.Json;

namespace Pipedrive.Models.Response
{
    public class AssociatedDeal
    {
        public long Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("status")]
        public DealStatus Status { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("stage_id")]
        public long StageId { get; set; }

        [JsonProperty("pipeline_id")]
        public long PipelineId { get; set; }
    }
}
