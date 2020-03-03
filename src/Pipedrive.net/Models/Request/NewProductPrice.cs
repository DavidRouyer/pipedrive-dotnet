using Newtonsoft.Json;

namespace Pipedrive.Models.Request
{
    public class NewProductPrice
    {
        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }

        [JsonProperty("cost")]
        public decimal? UnitCost { get; set; }

        [JsonProperty("overhead_cost")]
        public decimal? DirectCost { get; set; }
    }
}
