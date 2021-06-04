using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewDealProduct
    {
        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("item_price")]
        public decimal ItemPrice { get; set; }

        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("discount_percentage")]
        public decimal DiscountPercentage { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; } = 1;

        [JsonProperty("product_variation_id")]
        public long? ProductVariationId { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("enabled_flag")]
        public bool EnabledFlag { get; set; } = true;

        public NewDealProduct(long productId, decimal itemPrice, long quantity)
        {
            ProductId = productId;
            ItemPrice = itemPrice;
            Quantity = quantity;
        }
    }
}
