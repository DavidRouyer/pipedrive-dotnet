using Newtonsoft.Json;

namespace Pipedrive.Models.Request
{
    public class DealProductUpdate
    {

        [JsonProperty("id")]
        public long DealId { get; set; }

        [JsonProperty("deal_product_id")]
        public long DealProductId { get; set; }

        [JsonProperty("item_price")]
        public decimal ItemPrice { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("discount_percentage")]
        public decimal DiscountPercentage { get; set; }

        [JsonProperty("duration")]
        public long Duration { get; set; }

        [JsonProperty("product_variation_id")]
        public long? ProductVariationId { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("enabled_flag")]
        public bool EnabledFlag { get; set; }

        public DealProductUpdate(long dealId, long dealProductId, decimal itemPrice, int quantity)
        {
            DealId = dealId;
            DealProductId = dealProductId;
            ItemPrice = itemPrice;
            Quantity = quantity;
        }

    }
}
