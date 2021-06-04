using System;
using Newtonsoft.Json;
using Pipedrive.Converters;

namespace Pipedrive
{
    public class NewPayment
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("due_at")]
        [JsonConverter(typeof(DateWithoutTimeConverter))]
        public DateTime? DueAt { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
