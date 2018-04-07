using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Pipedrive
{
    public class ActivityUpdate
    {
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("done")]
        public ActivityDone Done { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("due_date")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("due_time")]
        public string DueTime { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("user_id")]
        public int? UserId { get; set; }

        [JsonProperty("deal_id")]
        public int? DealId { get; set; }

        [JsonProperty("person_id")]
        public int? PersonId { get; set; }

        [JsonProperty("participants")]
        public List<Participant> Participants { get; set; }

        [JsonProperty("org_id")]
        public int? OrgId { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}
