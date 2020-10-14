using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Models.Response;

namespace Pipedrive
{
    public abstract class AbstractLead
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        [JsonProperty("label_ids")]
        public List<Guid> LabelIds { get; set; }

        public CurrencyAmount Value { get; set; }

        [JsonProperty("expected_close_date")]
        public DateTime? ExpectedCloseDate { get; set; }

        public string Note { get; set; }

        [JsonProperty("person_id")]
        public long PersonId { get; set; }

        [JsonProperty("organization_id")]
        public long? OrganizationId { get; set; }

        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }

        [JsonProperty("source_name")]
        public string SourceName { get; set; }

        [JsonProperty("was_seen")]
        public bool WasSeen { get; set; }

        [JsonProperty("next_activity_id")]
        public long? NextActivityId { get; set; }

        [JsonProperty("add_time")]
        public DateTime? AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }
    }
}
