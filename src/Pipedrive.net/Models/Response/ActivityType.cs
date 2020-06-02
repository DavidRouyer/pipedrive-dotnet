using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class ActivityType
    {
        public long Id { get; set; }

        [JsonProperty("order_nr")]
        public long OrderNr { get; set; }

        public string Name { get; set; }

        [JsonProperty("key_string")]
        public string KeyString { get; set; }

        [JsonProperty("icon_key")]
        public ActivityTypeIcon IconKey { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        public string Color { get; set; }

        [JsonProperty("is_custom_flag")]
        public bool IsCustomFlag { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }

        public ActivityTypeUpdate ToUpdate()
        {
            return new ActivityTypeUpdate
            {
                Name = Name,
                IconKey = IconKey,
                Color = Color,
                OrderNr = OrderNr
            };
        }
    }
}
