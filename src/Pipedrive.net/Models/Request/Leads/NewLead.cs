using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pipedrive
{
    public class NewLead : IEntityWithCustomFields
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

		[JsonProperty("label_ids")]
		public List<string> LabelIds { get; set; } = new List<string>();

        [JsonProperty("person_id")]
        public long? PersonId { get; set; }

        [JsonProperty("organization_id")]
        public long? OrganizationId { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }

        [JsonProperty("expected_close_date")]
        public string ExpectedCloseDate { get; set; }

        [JsonProperty("visible_to")]

		public string VisibleTo { get; set; } = ((int)Visibility.shared).ToString();

        [JsonProperty("was_seen")]
        public bool WasSeen { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; } = new Dictionary<string, ICustomField>();

        public NewLead(string title)
        {
            this.Title = title;
        }
    }
}
