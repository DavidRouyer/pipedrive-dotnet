using System.Collections.Generic;

namespace Pipedrive
{
    public class DealsSummaryFilters
    {
        public static DealsSummaryFilters None
        {
            get { return new DealsSummaryFilters(); }
        }

        public DealStatus? Status { get; set; }

        public long? FilterId { get; set; }

        public long? UserId { get; set; }

        public long? StageId { get; set; }

        /// <summary>
        /// Get the query parameters that will be appending onto the search
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get
            {
                var d = new Dictionary<string, string>();
                if (Status.HasValue)
                {
                    d.Add("status", Status.Value.ToString());
                }

                if (FilterId.HasValue)
                {
                    d.Add("filter_id", FilterId.Value.ToString());
                }

                if (UserId.HasValue)
                {
                    d.Add("user_id", UserId.Value.ToString());
                }

                if (StageId.HasValue)
                {
                    d.Add("stage_id", StageId.Value.ToString());
                }

                return d;
            }
        }
    }
}
