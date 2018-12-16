using System.Collections.Generic;

namespace Pipedrive
{
    public class PersonDealFilters
    {
        public static PersonDealFilters None
        {
            get { return new PersonDealFilters(); }
        }

        public int? StartPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

        public DealStatus? Status { get; set; }

        public string Sort { get; set; }

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
                if (!string.IsNullOrWhiteSpace(Sort))
                {
                    d.Add("sort", Sort);
                }
                return d;
            }
        }
    }
}
