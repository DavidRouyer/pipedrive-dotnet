using System.Collections.Generic;

namespace Pipedrive
{
    public class LeadFilters
    {
        public static LeadFilters None
        {
            get { return new LeadFilters(); }
        }

        public int? StartPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

        public ArchivedStatus? ArchivedStatus { get; set; }

        /// <summary>
        /// Get the query parameters that will be appending onto the search
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get
            {
                var d = new Dictionary<string, string>();
                if (ArchivedStatus.HasValue)
                {
                    d.Add("archived_status", ArchivedStatus.Value.ToString());
                }

                return d;
            }
        }
    }
}
