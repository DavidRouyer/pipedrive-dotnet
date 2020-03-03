using Newtonsoft.Json;

namespace Pipedrive.Models.Response
{
    public class ProductPrice
    {
        public long Id { get; set; }

        [JsonProperty("product_id")]
        public long ProductId { get; set; }

        public decimal? Price { get; set; }

        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }

        [JsonProperty("cost")]
        public decimal? UnitCost { get; set; }

        [JsonProperty("overhead_cost")]
        public decimal? DirectCost { get; set; }
    }
}
