using Newtonsoft.Json;

namespace Pipedrive
{
    public class SimpleOrganization
    {
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("visible_to")]
        public string VisibleTo { get; set; }

        [JsonProperty("owner")]
        public SearchOwner Owner { get; set; }

        [JsonProperty("notes")]
        public string[] Notes { get; set; }
    }
}
