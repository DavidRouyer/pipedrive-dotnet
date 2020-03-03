using Newtonsoft.Json;

namespace Pipedrive.Models.Response
{
    public class CreatedDealProduct : AbstractDealProduct
    {
        [JsonProperty("company_id")]
        public long? CompanyId { get; set; }

        [JsonProperty("product_attachment_id")]
        public long? ProductAttachmentId { get; set; }
    }
}
