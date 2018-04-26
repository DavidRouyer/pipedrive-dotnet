using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Pipedrive
{
    public class NewActivity : IEntityWithCustomFields
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

        [JsonIgnore]
        public IDictionary<string, IField> CustomFields { get; set; } = new Dictionary<string, IField>();

        public NewActivity(string subject, string type)
        {
            this.Subject = subject;
            this.Type = type;
        }
    }

    public enum ActivityDone
    {
        NotDone = 0,
        Done = 1
    }
}
