using Newtonsoft.Json;

namespace Pipedrive
{
    public class SimpleOrganization
    {
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("visible_to")]
        public string VisibleTo { get; set; }

        [JsonProperty("details")]
        public object Details { get; set; }
    }
}
