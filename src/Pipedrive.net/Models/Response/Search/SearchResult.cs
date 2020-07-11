using Newtonsoft.Json;

namespace Pipedrive
{
    public class SearchResult<T>
    {
        [JsonProperty("result_score")]
        public double ResultScore { get; set; }

        public T Item { get; set; }
    }
}
