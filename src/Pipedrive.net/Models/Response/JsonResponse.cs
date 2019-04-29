using Newtonsoft.Json;

namespace Pipedrive
{
    public class JsonResponse<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }

        [JsonProperty("additional_data")]
        public AdditionalData AdditionalData { get; set; }

        [JsonProperty("related_objects")]
        public object RelatedObjects { get; set; }
    }
}
