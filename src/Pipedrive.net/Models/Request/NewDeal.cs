using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewDeal
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        [JsonProperty("person_id")]
        public int? PersonId { get; set; }

        [JsonProperty("org_id")]
        public int? OrgId { get; set; }

        [JsonProperty("stage_id")]
        public int? StageId { get; set; }

        [JsonProperty("status")]
        public DealStatus Status { get; set; }

        [JsonProperty("probability")]
        public double Probability { get; set; }

        [JsonProperty("lost_reason")]
        public string LostReason { get; set; }

        [JsonProperty("add_time")]
        public string AddTime { get; set; }

        [JsonProperty("visible_to")]
        public DealVisibility VisibleTo { get; set; }

        public NewDeal(string title)
        {
            this.Title = title;
        }
    }
}
