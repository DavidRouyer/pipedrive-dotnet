using Newtonsoft.Json;

namespace Pipedrive
{
    public class PersonFollower : Follower
    {
        [JsonProperty("person_id")]
        public long PersonId { get; set; }
    }
}
