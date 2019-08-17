using Newtonsoft.Json;

namespace Pipedrive
{
    public class PaginationInfo
    {
        [JsonProperty("start")]
        public long Start { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }

        [JsonProperty("more_items_in_collection")]
        public bool MoreItemsInCollection { get; set; }

        [JsonProperty("next_start")]
        public long? NextStart { get; set; }
    }
}
