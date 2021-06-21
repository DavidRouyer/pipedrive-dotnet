using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class LeadLabel
    {
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}
