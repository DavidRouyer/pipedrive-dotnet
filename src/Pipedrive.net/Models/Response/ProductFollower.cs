using Newtonsoft.Json;

namespace Pipedrive
{
    public class ProductFollower : Follower
    {
        [JsonProperty("product_id")]
        public long ProductId { get; set; }

    }
}
