using Newtonsoft.Json;

namespace Pipedrive
{
    public class SimplePerson
    {
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("org_id")]
        public long? OrgId { get; set; }

        [JsonProperty("org_name")]
        public string OrgName { get; set; }

        [JsonProperty("visible_to")]
        public string VisibleTo { get; set; }

        [JsonProperty("picture")]
        public SimplePicture Picture { get; set; }
    }
}
