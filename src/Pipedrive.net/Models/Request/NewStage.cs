using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewStage
    {
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pipeline_id")]
        public long PipelineId { get; set; }

        [JsonProperty("deal_probability")]
        public int DealProbability { get; set; }

        [JsonProperty("rotten_flag")]
        public bool RottenFlag { get; set; }

        [JsonProperty("rotten_days")]
        public int? RottenDays { get; set; }

        public NewStage(string name, long pipelineId)
        {
            this.Name = name;
            this.PipelineId = pipelineId;
        }
    }
}
