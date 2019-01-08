using System;
using System.Collections.Generic;

namespace Pipedrive
{
    public class ActivityFilters
    {
        public static ActivityFilters None
        {
            get { return new ActivityFilters(); }
        }

        public long? FilterId { get; set; }

        public string Type { get; set; }

        public int? StartPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ActivityDone? Done { get; set; }

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
                if (!string.IsNullOrWhiteSpace(Type))
                {
                    d.Add("type", Type);
                }
                if (StartDate.HasValue)
                {
                    d.Add("start_date", StartDate.Value.ToString("yyyy-MM-dd"));
                }
                if (EndDate.HasValue)
                {
                    d.Add("end_date", EndDate.Value.ToString("yyyy-MM-dd"));
                }
                if (Done.HasValue)
                {
                    d.Add("done", ((int)Done.Value).ToString());
                }
                return d;
            }
        }
    }
}
