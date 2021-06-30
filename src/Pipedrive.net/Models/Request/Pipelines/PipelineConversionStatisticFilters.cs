using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class PipelineConversionStatisticFilters
    {
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        [JsonProperty("end_date")]
        public DateTime EndDate { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        /// <summary>
        /// Get the query parameters that will be appending onto the search
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get
            {
                var d = new Dictionary<string, string>();
                d.Add("start_date", StartDate.ToString("yyyy-MM-dd"));
                d.Add("end_date", EndDate.ToString("yyyy-MM-dd"));

                if (UserId.HasValue)
                {
                    d.Add("user_id", UserId.Value.ToString());
                }

                return d;
            }
        }
    }
}
