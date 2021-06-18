using System.Collections.Generic;

namespace Pipedrive
{
    public class OrganizationMailMessageFilters
    {
        public static OrganizationMailMessageFilters None
        {
            get { return new OrganizationMailMessageFilters(); }
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
