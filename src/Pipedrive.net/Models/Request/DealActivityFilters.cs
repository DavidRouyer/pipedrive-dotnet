using System.Collections.Generic;

namespace Pipedrive
{
    public class DealActivityFilters
    {
        public static DealActivityFilters None
        {
            get { return new DealActivityFilters(); }
        }

        public ActivityDone? Done { get; set; }

        public string Exclude { get; set; }

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
                if (Done.HasValue)
                {
                    d.Add("done", ((int)Done.Value).ToString());
                }
                if (!string.IsNullOrWhiteSpace(Exclude))
                {
                    d.Add("exclude", Exclude);
                }
                return d;
            }
        }
    }
}
