using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewPerson : IEntityWithCustomFields
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("org_id")]
        public long OrgId { get; set; }

        [JsonProperty("email")]
        public List<Email> Email { get; set; } = new List<Email>();

        [JsonProperty("phone")]
        public List<Phone> Phone { get; set; } = new List<Phone>();

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; } = Visibility.shared;

        [JsonProperty("marketing_status")]
        public MarketingStatus? MarketingStatus { get; set; }

        [JsonProperty("add_time")]
        public DateTime? AddTime { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; } = new Dictionary<string, ICustomField>();

        public NewPerson(string name)
        {
            this.Name = name;
        }
    }
}
