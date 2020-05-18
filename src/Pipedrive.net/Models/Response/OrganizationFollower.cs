using Newtonsoft.Json;

namespace Pipedrive
{
    public class OrganizationFollower : Follower
    {
        [JsonProperty("organization_id")]
        public long OrganizationId { get; set; }
    }
}
