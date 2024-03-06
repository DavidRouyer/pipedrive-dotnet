using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Models.Response;

namespace Pipedrive
{
    public class NewLead : IEntityWithCustomFields
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("owner_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? OwnerId { get; set; }

        [JsonProperty("label_ids", NullValueHandling = NullValueHandling.Ignore)]
        public IEnumerable<Guid> LabelIds { get; set; }

        [JsonProperty("person_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? PersonId { get; set; }

        [JsonProperty("organization_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? OrganizationId { get; set; }

        [JsonProperty("value", NullValueHandling = NullValueHandling.Ignore)]
        public CurrencyAmount Value { get; set; }

        [JsonProperty("expected_close_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? ExpectedCloseDate { get; set; }

        [JsonProperty("visible_to", NullValueHandling = NullValueHandling.Ignore)]
        public Visibility? VisibleTo { get; set; }

        [JsonProperty("was_seen", NullValueHandling = NullValueHandling.Ignore)]
        public bool? WasSeen { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; } = new Dictionary<string, ICustomField>();

        public NewLead(string title)
        {
            this.Title = title;
        }
    }
}
