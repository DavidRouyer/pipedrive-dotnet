using System.Collections.Generic;

namespace Pipedrive
{
    public class PersonFileFilters
    {
        public static PersonFileFilters None
        {
            get { return new PersonFileFilters(); }
        }

        public int? StartPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

        public string IncludeDeletedFiles { get; set; }

        public string Sort { get; set; }

        /// <summary>
        /// Get the query parameters that will be appending onto the search
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get
            {
                var d = new Dictionary<string, string>();
                if (!string.IsNullOrWhiteSpace(IncludeDeletedFiles))
                {
                    d.Add("include_deleted_files", IncludeDeletedFiles);
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
