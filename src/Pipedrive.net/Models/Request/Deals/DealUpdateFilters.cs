using System.Collections.Generic;

namespace Pipedrive
{
    public class DealUpdateFilters
    {
        public static DealUpdateFilters None
        {
            get { return new DealUpdateFilters(); }
        }

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
                return d;
            }
        }
    }
}
