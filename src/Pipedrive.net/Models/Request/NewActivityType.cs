using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewActivityType
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("icon_key")]
        public ActivityTypeIcon IconKey { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        public NewActivityType(string name, ActivityTypeIcon iconKey)
        {
            this.Name = name;
            this.IconKey = iconKey;
        }
    }
}
