using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pipedrive
{
    public class NewOrganization : IEntityWithCustomFields
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        [JsonProperty("add_time")]
        public string AddTime { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; } = new Dictionary<string, ICustomField>();

        public NewOrganization(string name)
        {
            this.Name = name;
        }
    }
}
