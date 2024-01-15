using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Pipedrive.Models.Response.Leads
{
    /// <summary>
    /// https://developers.pipedrive.com/docs/api/v1/Leads#addLead
    /// </summary>
    /*
     {
          "title": "<string>",
          "owner_id": "<integer>",
          "label_ids": [
            "<uuid>",
            "<uuid>"
          ],
          "person_id": "<integer>",
          "organization_id": "<integer>",
          "value": {
            "amount": "<number>",
            "currency": "<string>"
          },
          "expected_close_date": "<date>",
          "visible_to": "<string>",
          "was_seen": "<boolean>"
     }
     */
    public class NewLead
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonIgnore]
        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonIgnore]
        [JsonProperty("creator_id")]
        public long CreatorId { get; set; }

        [JsonIgnore]
        [JsonProperty("label_ids")]
        public List<Guid> LabelIds { get; set; }

        [JsonIgnore]
        [JsonProperty("value")]
        public CurrencyAmount Value { get; set; }

        [JsonIgnore]
        [JsonProperty("expected_close_date")]
        public DateTime? ExpectedCloseDate { get; set; }

        [JsonIgnore]
        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("person_id")]
        public long PersonId { get; set; }

        [JsonProperty("organization_id")]
        public long? OrganizationId { get; set; }

        [JsonIgnore]
        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }

        [JsonIgnore]
        [JsonProperty("source_name")]
        public string SourceName { get; set; }

        [JsonIgnore]
        [JsonProperty("was_seen")]
        public bool WasSeen { get; set; }

        [JsonIgnore]
        [JsonProperty("next_activity_id")]
        public long? NextActivityId { get; set; }

        [JsonIgnore]
        [JsonProperty("add_time")]
        public DateTime? AddTime { get; set; }

        [JsonIgnore]
        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }
    }
}
