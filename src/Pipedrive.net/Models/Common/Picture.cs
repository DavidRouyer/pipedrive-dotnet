using Newtonsoft.Json;
using System;

namespace Pipedrive
{
    public class Picture
    {
        [JsonProperty("item_type")]
        public string ItemType { get; set;}

        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("update_time")]
        [JsonConverter(typeof(ZeroDateConverter))]
        public DateTime? UpdateTime { get; set; }

        [JsonProperty("added_by_user_id")]
        public long AddedByUserId { get; set; }

        [JsonProperty("pictures")]
        public object Pictures { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
