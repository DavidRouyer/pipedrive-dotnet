using Newtonsoft.Json;

namespace Pipedrive
{
    public class Currency
    {
        public long Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        [JsonProperty("decimal_points")]
        public int DecimalPoints { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("is_custom_flag")]
        public bool IsCustomFlag { get; set; }
    }
}
