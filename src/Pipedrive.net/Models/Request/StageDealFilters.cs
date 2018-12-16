using System.Collections.Generic;

namespace Pipedrive
{
    public class StageDealFilters
    {
        public static StageDealFilters None
        {
            get { return new StageDealFilters(); }
        }

        public long? FilterId { get; set; }

        public long? UserId { get; set; }

        public bool? Everyone { get; set; }

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
                if (UserId.HasValue)
                {
                    d.Add("user_id", UserId.Value.ToString());
                }
                if (Everyone.HasValue)
                {
                    d.Add("everyone", Everyone.Value.ToString());
                }
                return d;
            }
        }
    }
}
