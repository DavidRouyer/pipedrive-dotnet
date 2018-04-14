using Newtonsoft.Json;

namespace Pipedrive
{
    public class Email
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("primary")]
        public bool Primary { get; set; }
    }
}
