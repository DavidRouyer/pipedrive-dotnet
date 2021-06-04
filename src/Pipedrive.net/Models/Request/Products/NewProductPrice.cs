using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewProductPrice
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("cost")]
        public decimal? Cost { get; set; }

        [JsonProperty("overhead_cost")]
        public decimal? OverheadCost { get; set; }
    }
}
