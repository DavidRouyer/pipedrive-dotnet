using Newtonsoft.Json;

namespace Pipedrive.Webhooks
{
    public class MatchesFilters
    {
        [JsonProperty("previous")]
        public string[] Previous { get; set; }

        [JsonProperty("current")]
        public string[] Current { get; set; }
    }
}
