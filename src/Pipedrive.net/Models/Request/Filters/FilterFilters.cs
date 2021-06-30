using System.Collections.Generic;

namespace Pipedrive
{
    public class FilterFilters
    {
        public static FilterFilters None
        {
            get { return new FilterFilters(); }
        }

        public FilterType? Type { get; set; }

        /// <summary>
        /// Get the query parameters that will be appending onto the search
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get
            {
                var d = new Dictionary<string, string>();
                if (Type.HasValue)
                {
                    d.Add("type", Type.Value.ToString());
                }

                return d;
            }
        }
    }
}
