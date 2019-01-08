using Newtonsoft.Json;

namespace Pipedrive.Internal
{
    internal class JsonResponse<T>
    {
        public bool Success { get; set; }

        public T Data { get; set; }

        [JsonProperty("additional_data")]
        public AdditionalData AdditionalData { get; set; }

        [JsonProperty("related_objects")]
        public object RelatedObjects { get; set; }
    }
}
