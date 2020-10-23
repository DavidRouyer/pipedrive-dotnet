using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class Stage
    {
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pipeline_id")]
        public long PipelineId { get; set; }

        [JsonProperty("order_nr")]
        public long OrderNr { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("deal_probability")]
        public long DealProbability { get; set; }

        [JsonProperty("rotten_flag")]
        public bool RottenFlag { get; set; }

        [JsonProperty("rotten_days")]
        public int? RottenDays { get; set; }

        [JsonProperty("deals_summary")]
        public object DealsSummary { get; set; }

        [JsonProperty("add_time")]
        public DateTime? AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }

        public StageUpdate ToUpdate()
        {
            return new StageUpdate
            {
                Name = Name,
                PipelineId = PipelineId,
                DealProbability = DealProbability,
                RottenFlag = RottenFlag,
                RottenDays = RottenDays
            };
        }
    }
}
