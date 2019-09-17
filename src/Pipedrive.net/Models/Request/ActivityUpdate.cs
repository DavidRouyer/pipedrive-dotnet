﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;

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
        public long? UserId { get; set; }

        [JsonProperty("deal_id")]
        public long? DealId { get; set; }

        [JsonProperty("person_id")]
        public long? PersonId { get; set; }

        [JsonProperty("participants")]
        public List<Participant> Participants { get; set; }

        [JsonProperty("org_id")]
        public long? OrgId { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }
    }
}
