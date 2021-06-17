using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class DealsTimelineFilters
    {
        [JsonProperty("start_date")]
        public DateTime StartDate { get; set; }

        public DateInterval Interval { get; set; }

        public long Amount { get; set; }

        [JsonProperty("field_key")]
        public string FieldKey { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("pipeline_id")]
        public long? PipelineId { get; set; }

        [JsonProperty("filter_id")]
        public long? FilterId { get; set; }

        [JsonProperty("exclude_deals")]
        public ExcludeDeals ExcludeDeals { get; set; }

        [JsonProperty("totals_convert_currency")]
        public string TotalsConvertCurrency { get; set; }

        /// <summary>
        /// Get the query parameters that will be appending onto the search
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get
            {
                var d = new Dictionary<string, string>();

                d.Add("start_date", StartDate.ToString("yyyy-MM-dd"));
                d.Add("interval", Interval.ToString().ToLower());
                d.Add("amount", Amount.ToString());
                d.Add("field_key", FieldKey);

                if (FilterId.HasValue)
                {
                    d.Add("filter_id", FilterId.Value.ToString());
                }

                if (PipelineId.HasValue)
                {
                    d.Add("pipeline_id", PipelineId.Value.ToString());
                }

                if (UserId.HasValue)
                {
                    d.Add("user_id", UserId.Value.ToString());
                }

                d.Add("exclude_deals", ((long)ExcludeDeals).ToString());

                if (!string.IsNullOrWhiteSpace(TotalsConvertCurrency))
                {
                    d.Add("totals_convert_currency", TotalsConvertCurrency);
                }

                return d;
            }
        }
    }
}
