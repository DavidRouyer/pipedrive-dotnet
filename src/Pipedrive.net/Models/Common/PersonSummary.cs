using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pipedrive
{
    public class PersonSummary
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        List<Email> Email { get; set; }

        [JsonProperty("phone")]
        List<Phone> Phone { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
