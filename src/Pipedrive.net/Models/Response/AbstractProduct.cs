using System;
using Newtonsoft.Json;

namespace Pipedrive.Models.Response
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
        public bool Active { get; set; }

        public bool Selectable { get; set; }

        [JsonProperty("first_char")]
        public string FirstCharacter { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        [JsonProperty("owner_id")]
        public AssociatedUser Owner { get; set; }

        [JsonProperty("files_count")]
        public int? FilesCount { get; set; }

        [JsonProperty("followers_count")]
        public int FollowerCount { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }
    }
}
