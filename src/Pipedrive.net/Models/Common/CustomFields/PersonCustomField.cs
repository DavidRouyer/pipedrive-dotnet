using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Pipedrive.CustomFields
{
    public class PersonCustomField : ICustomField
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        List<Email> Email { get; set; }

        [JsonProperty("phone")]
        List<Phone> Phone { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        public override string ToString()
        {
            return $"{Name}, <{string.Join(", ", Email.Select(e => e.Value))}>";
        }
    }
}
