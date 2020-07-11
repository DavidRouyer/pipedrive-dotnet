using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public abstract class AbstractProduct
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Unit { get; set; }

        public decimal Tax { get; set; }

        public string Category { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        public bool Selectable { get; set; }

        [JsonProperty("first_char")]
        public string FirstChar { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        [JsonProperty("owner_id")]
        public AssociatedUser Owner { get; set; }

        [JsonProperty("files_count")]
        public long? FilesCount { get; set; }

        [JsonProperty("followers_count")]
        public long FollowersCount { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }
    }
}
