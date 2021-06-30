using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class LeadLabel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }
    }
}
