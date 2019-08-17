using Newtonsoft.Json;
using System;

namespace Pipedrive
{
    public class DealChange : IDealUpdateEntity
    {
        public long Id { get; set; }

        [JsonProperty("item_id")]
        public long ItemId { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("old_value")]
        public decimal OldValue { get; set; }

        [JsonProperty("new_value")]
        public decimal NewValue { get; set; }

        [JsonProperty("is_bulk_update_flag")]
        public string IsBulkUpdateFlag { get; set; }

        [JsonProperty("log_time")]
        public DateTime LogTime { get; set; }

        [JsonProperty("additional_data")]
        public object AdditionalData { get; set; }
    }
}
