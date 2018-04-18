using Newtonsoft.Json;

namespace Pipedrive
{
    public class OrganizationSummary : IField
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("people_count")]
        public int PeopleCount { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("cc_email")]
        public string CcEmail { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
