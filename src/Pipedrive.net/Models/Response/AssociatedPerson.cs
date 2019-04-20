using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pipedrive.Models.Response
{
    public class AssociatedPerson
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public List<Email> Email { get; set; }

        [JsonProperty("phone")]
        public List<Phone> Phone { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
