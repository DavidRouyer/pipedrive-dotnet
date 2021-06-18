using System.Collections.Generic;

namespace Pipedrive
{
    public class DealFileFilters
    {
        public static DealFileFilters None
        {
            get { return new DealFileFilters(); }
        }

        public int? StartPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

        public bool? IncludeDeletedFiles { get; set; }

        public string Sort { get; set; }

        /// <summary>
        /// Get the query parameters that will be appending onto the search
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get
            {
                var d = new Dictionary<string, string>();
                if (IncludeDeletedFiles.HasValue)
                {
                    d.Add("include_deleted_files", IncludeDeletedFiles.Value == true ? 1.ToString() : 0.ToString());
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
