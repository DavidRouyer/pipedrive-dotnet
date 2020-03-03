using Newtonsoft.Json;

namespace Pipedrive.Models.Response
{
    public class UpdatedDealProduct : AbstractDealProduct
    {

        [JsonProperty("company_id")]
        public long? CompanyId { get; set; }

    }
}
