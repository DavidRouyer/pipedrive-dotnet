using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewOrganization
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        [JsonProperty("add_time")]
        public string AddTime { get; set; }

        public NewOrganization(string name)
        {
            this.Name = name;
        }
    }
}
