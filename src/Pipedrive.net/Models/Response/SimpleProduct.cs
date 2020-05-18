using Newtonsoft.Json;

namespace Pipedrive.Models.Response
{
    public class SimpleProduct
    {
        public long Id { get; set; }

        [JsonProperty("variation_id")]
        public long VariationId { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        [JsonProperty("variation_name")]
        public string VariationName { get; set; }

        public decimal Price { get; set; }

        [JsonProperty("price_formatted")]
        public string PriceFormatted { get; set; }
    }
}
