using System.Collections.Generic;

namespace Pipedrive
{
    public class OrganizationSearchFilters
    {
        public static OrganizationSearchFilters None
        {
            get { return new OrganizationSearchFilters(); }
        }

        public bool? ExactMatch { get; set; }

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
                if (ExactMatch.HasValue)
                {
                    d.Add("exact_match", ExactMatch.Value.ToString());
                }

                return d;
            }
        }
    }
}
