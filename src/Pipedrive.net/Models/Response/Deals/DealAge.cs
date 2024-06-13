using Newtonsoft.Json;

namespace Pipedrive.Models.Response.Deals
{
    public class DealAge
    {
        [JsonProperty("y")]
        public int Y { get; set; }

        [JsonProperty("m")]
        public byte M { get; set; }

        [JsonProperty("d")]
        public byte D { get; set; }

        [JsonProperty("h")]
        public byte H { get; set; }

        [JsonProperty("i")]
        public byte I { get; set; }

        [JsonProperty("s")]
        public byte S { get; set; }

        [JsonProperty("total_seconds")]
        public long TotalSeconds { get; set; }
    }
}
