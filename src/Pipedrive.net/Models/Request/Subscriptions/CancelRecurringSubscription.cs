using System;
using Newtonsoft.Json;
using Pipedrive.Converters;

namespace Pipedrive
{
    public class CancelRecurringSubscription
    {
        [JsonProperty("end_date")]
        [JsonConverter(typeof(DateWithoutTimeConverter))]
        public DateTime EndDate { get; set; }
    }
}
