using Newtonsoft.Json;

namespace Pipedrive
{
    public class SimpleProduct
    {
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("visible_to")]
        public string VisibleTo { get; set; }
    }
}
