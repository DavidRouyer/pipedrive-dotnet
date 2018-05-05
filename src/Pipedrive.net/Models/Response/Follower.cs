using Newtonsoft.Json;
using System;

namespace Pipedrive
{
    public class Follower
    {
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("deal_id")]
        public long DealId { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }
    }
}
