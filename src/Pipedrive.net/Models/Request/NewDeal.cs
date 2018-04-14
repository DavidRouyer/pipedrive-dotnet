using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewDeal
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("person_id")]
        public long? PersonId { get; set; }

        [JsonProperty("org_id")]
        public long? OrgId { get; set; }

        [JsonProperty("stage_id")]
        public long? StageId { get; set; }

        [JsonProperty("status")]
        public DealStatus Status { get; set; }

        [JsonProperty("probability")]
        public double Probability { get; set; }

        [JsonProperty("lost_reason")]
        public string LostReason { get; set; }

        [JsonProperty("add_time")]
        public string AddTime { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        public NewDeal(string title)
        {
            this.Title = title;
        }
    }
}
