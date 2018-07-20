using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pipedrive.Internal;
using System;
using System.Collections.Generic;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class DealUpdate : IEntityWithCustomFields
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public long? Value { get; set; }

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
        public DealStatus? Status { get; set; }

        [JsonProperty("probability")]
        public double? Probability { get; set; }

        [JsonProperty("lost_reason")]
        public string LostReason { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; }
    }
}
