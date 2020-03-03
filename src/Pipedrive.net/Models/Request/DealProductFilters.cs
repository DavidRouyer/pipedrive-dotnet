using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pipedrive.Models.Request
{
    public class DealProductFilters
    {
        public static DealProductFilters None => new DealProductFilters();

        public int? StartPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

        [JsonProperty("include_product_data")]
        public string IncludeProductData { get; set; }

        /// <summary>
        /// Get the query parameters that will be appending onto the search
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get
            {
                var d = new Dictionary<string, string>();
                if (!string.IsNullOrWhiteSpace(IncludeProductData))
                {
                    d.Add("include_product_data", IncludeProductData);
                }

                return d;
            }
        }
    }
}
