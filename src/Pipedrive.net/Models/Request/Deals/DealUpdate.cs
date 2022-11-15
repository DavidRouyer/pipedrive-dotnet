using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class DealUpdate : IEntityWithCustomFields
    {
        [JsonProperty("title",  NullValueHandling=NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("value",  NullValueHandling=NullValueHandling.Ignore)]
        public decimal? Value { get; set; }

        [JsonProperty("currency",  NullValueHandling=NullValueHandling.Ignore)]
        public string Currency { get; set; }

        [JsonProperty("user_id",  NullValueHandling=NullValueHandling.Ignore)]
        public long? UserId { get; set; }

        [JsonProperty("person_id",  NullValueHandling=NullValueHandling.Ignore)]
        public long? PersonId { get; set; }

        [JsonProperty("org_id",  NullValueHandling=NullValueHandling.Ignore)]
        public long? OrgId { get; set; }

        [JsonProperty("stage_id",  NullValueHandling=NullValueHandling.Ignore)]
        public long? StageId { get; set; }

        [JsonProperty("status",  NullValueHandling=NullValueHandling.Ignore)]
        [JsonConverter(typeof(StringEnumConverter))]
        public DealStatus? Status { get; set; }

        [JsonProperty("probability",  NullValueHandling=NullValueHandling.Ignore)]
        public double? Probability { get; set; }

        [JsonProperty("lost_reason",  NullValueHandling=NullValueHandling.Ignore)]
        public string LostReason { get; set; }

        [JsonProperty("visible_to",  NullValueHandling=NullValueHandling.Ignore)]
        public Visibility? VisibleTo { get; set; }

        [JsonProperty("add_time",  NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? AddTime { get; set; }

        [JsonProperty("close_time",  NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? CloseTime { get; set; }

        [JsonProperty("lost_time",  NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? LostTime { get; set; }

        [JsonProperty("first_won_time",  NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? FirstWonTime { get; set; }

        [JsonProperty("won_time",  NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? WonTime { get; set; }

        [JsonProperty("expected_close_date",  NullValueHandling=NullValueHandling.Ignore)]
        public DateTime? ExpectedCloseDate { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; }
    }
}
