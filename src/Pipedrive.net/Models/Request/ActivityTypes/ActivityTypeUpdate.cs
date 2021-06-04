using Newtonsoft.Json;

namespace Pipedrive
{
    public class ActivityTypeUpdate
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon_key")]
        public ActivityTypeIcon IconKey { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("order_nr")]
        public long OrderNr { get; set; }
    }
}
