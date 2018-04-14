using Newtonsoft.Json;

namespace Pipedrive
{
    public class OrganizationUpdate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_id")]
        public long? OwnerId { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }
    }
}
