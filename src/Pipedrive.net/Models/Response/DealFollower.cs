using Newtonsoft.Json;

namespace Pipedrive
{
    public class DealFollower : Follower
    {

        [JsonProperty("deal_id")]
        public long DealId { get; set; }
    }
}
