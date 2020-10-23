using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public abstract class Follower
    {
        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("add_time")]
        public DateTime? AddTime { get; set; }
    }
}
