using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class SimplePerson
    {
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phones")]
        public string[] Phones { get; set; }

        [JsonProperty("emails")]
        public string[] Emails { get; set; }

        [JsonProperty("visible_to")]
        public string VisibleTo { get; set; }

        [JsonProperty("owner")]
        public SearchOwner Owner { get; set; }

        [JsonProperty("organization")]
        public SearchOrganization Organization { get; set; }

        [JsonProperty("pictures")]
        public List<SimplePicture> Pictures { get; set; }
    }
}
