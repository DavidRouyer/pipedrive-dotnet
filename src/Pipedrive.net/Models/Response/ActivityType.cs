using Newtonsoft.Json;
using System;

namespace Pipedrive
{
    public class ActivityType
    {
        public int Id { get; set; }

        [JsonProperty("order_nr")]
        public int OrderNr { get; set; }

        public string Name { get; set; }

        [JsonProperty("key_string")]
        public string KeyString { get; set; }

        [JsonProperty("icon_key")]
        public string IconKey { get; set; }

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
            ActivityTypeIcon iconKey = ActivityTypeIcon.Addressbook;
            if (!Enum.TryParse(IconKey, out iconKey))
            {
                throw new Exception($"Icon key '{IconKey}' does not exist in ActivityTypeIcon");
            }

            return new ActivityTypeUpdate
            {
                Name = Name,
                IconKey = iconKey,
                Color = Color,
                OrderNr = OrderNr
            };
        }
    }
}
