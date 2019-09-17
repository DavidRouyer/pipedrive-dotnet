using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewDealProduct
    {

        [JsonProperty("id")]
        public long DealId { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("item_price")]
        public decimal ItemPrice { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("discount_percentage")]
        public decimal DiscountPercentage { get; set; }

        [JsonProperty("duration")]
        public long During { get; set; }

        [JsonProperty("product_variation_id")]
        public long? ProductVariationId { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("enabled_flag")]
        public bool EnabledFlag { get; set; }

        public NewDealProduct(long dealId, long productId, decimal itemPrice, int quantity)
        {
            DealId = dealId;
            ProductId = productId;
            ItemPrice = itemPrice;
            Quantity = quantity;
        }

    }
}
