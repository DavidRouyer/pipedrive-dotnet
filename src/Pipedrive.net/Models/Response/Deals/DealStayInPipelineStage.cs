using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Converters;

namespace Pipedrive.Models.Response.Deals
{
    public class DealStayInPipelineStage
    {
        [JsonConverter(typeof(TimesInStageDataConverter))]
        [JsonProperty("times_in_stages")]
        public Dictionary<long, long> TimesInStages { get; set; }

        [JsonProperty("order_of_stages")]
        public List<long> OrderOfStages { get; set; }
    }
}
