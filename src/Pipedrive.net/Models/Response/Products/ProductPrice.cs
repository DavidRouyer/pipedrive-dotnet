using Newtonsoft.Json;

namespace Pipedrive
{
    public class ProductPrice
    {
        public long Id { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        [JsonProperty("price")]
        public decimal? Price { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("cost")]
        public decimal? Cost { get; set; }

        [JsonProperty("overhead_cost")]
        public decimal? OverheadCost { get; set; }
    }
}
