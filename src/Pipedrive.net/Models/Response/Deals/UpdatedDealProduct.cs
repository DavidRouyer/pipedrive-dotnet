using Newtonsoft.Json;

namespace Pipedrive
{
    public class UpdatedDealProduct : AbstractDealProduct
    {
        [JsonProperty("company_id")]
        public long? CompanyId { get; set; }
    }
}
