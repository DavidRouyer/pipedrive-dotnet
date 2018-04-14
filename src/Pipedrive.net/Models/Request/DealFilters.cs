using System.Collections.Generic;

namespace Pipedrive
{
    public class DealFilters
    {
        public static DealFilters None
        {
            get { return new DealFilters(); }
        }

        public int? FilterId { get; set; }

        public long? StageId { get; set; }

        public DealStatus? Status { get; set; }

        public string Sort { get; set; }

        public int? StartPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

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
                if (StageId.HasValue)
                {
                    d.Add("stage_id", FilterId.Value.ToString());
                }
                if (Status.HasValue)
                {
                    d.Add("status", Status.Value.ToString());
                }
                if (!string.IsNullOrWhiteSpace(Sort))
                {
                    d.Add("sort", Sort);
                }
                return d;
            }
        }
    }
}
