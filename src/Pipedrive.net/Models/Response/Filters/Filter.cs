using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class Filter
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        public string Type { get; set; }

        [JsonProperty("temporary_flag")]
        public string TemporaryFlag { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }

        [JsonProperty("visible_to")]
        public long VisibleTo { get; set; }

        [JsonProperty("custom_view_id")]
        public long? CustomViewId { get; set; }
    }
}
