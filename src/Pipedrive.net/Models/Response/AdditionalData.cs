using Newtonsoft.Json;

namespace Pipedrive
{
    public class AdditionalData
    {
        [JsonProperty("pagination")]
        public PaginationInfo Pagination { get; set; }
    }
}
