using Newtonsoft.Json;

namespace Pipedrive
{
    public class PipelineMovementStatistic
    {
        [JsonProperty("movements_between_stages")]
        public PipelineMovementsBetweenStages MovementsBetweenStages { get; set; }

        [JsonProperty("new_deals")]
        public PipelineMovementsDealStatistics NewDeals { get; set; }

        [JsonProperty("won_deals")]
        public PipelineMovementsDealStatistics WonDeals { get; set; }

        [JsonProperty("lost_deals")]
        public PipelineMovementsDealStatistics LostDeals { get; set; }

        [JsonProperty("average_age_in_days")]
        public PipelineMovementsAverageAge AverageAgeInDays { get; set; }
    }
}
