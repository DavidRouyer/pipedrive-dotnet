using Newtonsoft.Json;

namespace Pipedrive
{
    public class DealFieldUpdate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("options")]
        public object Options { get; set; }
    }
}
