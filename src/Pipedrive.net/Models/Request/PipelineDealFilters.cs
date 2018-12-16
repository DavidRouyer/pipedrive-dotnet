using System.Collections.Generic;

namespace Pipedrive
{
    public class PipelineDealFilters
    {
        public static PipelineDealFilters None
        {
            get { return new PipelineDealFilters(); }
        }

        public long? FilterId { get; set; }

        public long? UserId { get; set; }

        public bool? Everyone { get; set; }

        public long? StageId { get; set; }

        public int? StartPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

        public bool? GetSummary { get; set; }

        public string TotalsConvertCurrency { get; set; }

        /// <summary>
        /// Get the query parameters that will be appending onto the search
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get
            {
                var d = new Dictionary<string, string>();
                if (FilterId.HasValue)
                {
                    d.Add("filter_id", FilterId.Value.ToString());
                }
                if (UserId.HasValue)
                {
                    d.Add("user_id", UserId.Value.ToString());
                }
                if (Everyone.HasValue)
                {
                    d.Add("everyone", Everyone.Value.ToString());
                }
                if (StageId.HasValue)
                {
                    d.Add("stage_id", StageId.Value.ToString());
                }
                if (GetSummary.HasValue)
                {
                    d.Add("get_summary", GetSummary.Value.ToString());
                }
                if (!string.IsNullOrWhiteSpace(TotalsConvertCurrency))
                {
                    d.Add("totals_convert_currency", TotalsConvertCurrency);
                }
                return d;
            }
        }
    }
}
