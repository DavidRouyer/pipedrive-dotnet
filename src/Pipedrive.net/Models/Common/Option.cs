using Newtonsoft.Json;

namespace Pipedrive
{
    public class Option
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
