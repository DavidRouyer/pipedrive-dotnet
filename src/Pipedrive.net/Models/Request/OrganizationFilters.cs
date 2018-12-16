using System.Collections.Generic;

namespace Pipedrive
{
    public class OrganizationFilters
    {
        public static OrganizationFilters None
        {
            get { return new OrganizationFilters(); }
        }

        public long? FilterId { get; set; }

        public char? FirstChar { get; set; }

        public int? StartPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

        public string Sort { get; set; }

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
                if (FirstChar.HasValue)
                {
                    d.Add("first_char", FirstChar.Value.ToString());
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
