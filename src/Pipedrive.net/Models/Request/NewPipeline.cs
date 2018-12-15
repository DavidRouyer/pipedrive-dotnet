using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewPipeline
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("order_nr")]
        public int OrderNr { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("deal_probability")]
        public bool DealProbability { get; set; }

        public NewPipeline(string name)
        {
            this.Name = name;
        }
    }
}
