using Newtonsoft.Json;
using System.Collections.Generic;

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
        public List<Email> Email { get; set; }

        [JsonProperty("phone")]
        public List<Phone> Phone { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        [JsonProperty("add_time")]
        public string AddTime { get; set; }

        [JsonIgnore]
        public IDictionary<string, IField> CustomFields { get; set; } = new Dictionary<string, IField>();

        public NewPerson(string name)
        {
            this.Name = name;
        }
    }
}
