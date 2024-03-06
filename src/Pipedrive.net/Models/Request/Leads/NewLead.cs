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

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("label_ids")]
        public IEnumerable<Guid> LabelIds { get; set; }

        [JsonProperty("person_id")]
        public long PersonId { get; set; }

        [JsonProperty("person_id")]
        public long OrganizationId { get; set; }

        public CurrencyAmount Value { get; set; }

        [JsonProperty("expected_close_date")]
        public DateTime? ExpectedCloseDate { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; } = Visibility.ownerVisibilityGroup;

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
