using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace Pipedrive
{
    public class NewDeal : IEntityWithCustomFields
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }

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
        [JsonConverter(typeof(StringEnumConverter))]
        public DealStatus Status { get; set; }

        [JsonProperty("probability")]
        public double Probability { get; set; }

        [JsonProperty("lost_reason")]
        public string LostReason { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        [JsonProperty("add_time")]
        public DateTime? AddTime { get; set; }

        [JsonProperty("close_time")]
        public DateTime? CloseTime { get; set; }

        [JsonProperty("lost_time")]
        public DateTime? LostTime { get; set; }

        [JsonProperty("first_won_time")]
        public DateTime? FirstWonTime { get; set; }

        [JsonProperty("won_time")]
        public DateTime? WonTime { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; } = new Dictionary<string, ICustomField>();

        public NewDeal(string title)
        {
            this.Title = title;
        }
    }
}
