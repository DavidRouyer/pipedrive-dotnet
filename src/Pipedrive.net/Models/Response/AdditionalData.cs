using Newtonsoft.Json;

namespace Pipedrive.Internal
{
    internal class AdditionalData
    {
        [JsonProperty("pagination")]
        public PaginationInfo Pagination { get; set; }
    }
}
