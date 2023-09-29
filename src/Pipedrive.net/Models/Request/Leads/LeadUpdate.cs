using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Pipedrive.Internal;
using Pipedrive.Models.Response;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class LeadUpdate : IEntityWithCustomFields
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("label_ids")]
        public List<Guid> LabelIds { get; set; }

        [JsonProperty("person_id")]
        public long? PersonId { get; set; }

        [JsonProperty("organization_id")]
        public long? OrganizationId { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("expected_close_date")]
        public DateTime? ExpectedCloseDate { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; } = Visibility.shared;

        [JsonProperty("was_seen")]
        public bool WasSeen { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; } = new Dictionary<string, ICustomField>();
    }
}
