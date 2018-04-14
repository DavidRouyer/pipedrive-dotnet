using Newtonsoft.Json;

namespace Pipedrive
{
    public class Phone
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
}
