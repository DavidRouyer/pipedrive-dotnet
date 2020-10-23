using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public abstract class AbstractDealProduct
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("deal_id")]
        public long? DealId { get; set; }

        [JsonProperty("order_nr")]
        public long? OrderNumber { get; set; }

        [JsonProperty("product_id")]
        public long? ProductId { get; set; }

        [JsonProperty("product_variation_id")]
        public long? ProductVariationId { get; set; }

        [JsonProperty("item_price")]
        public decimal ItemPrice { get; set; }

        [JsonProperty("discount_percentage")]
        public decimal DiscountPercentage { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("duration_unit")]
        public long? DurationUnit { get; set; }

        [JsonProperty("sum_no_discount")]
        public decimal SumNoDiscount { get; set; }

        [JsonProperty("sum")]
        public decimal Sum { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("enabled_flag")]
        public bool EnabledFlag { get; set; }

        [JsonProperty("add_time")]
        public DateTime? AddTime { get; set; }

        [JsonProperty("last_edit")]
        public DateTime? LastEdit { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("tax")]
        public decimal Tax { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }
    }
}
