using System;
using System.Collections.Generic;

namespace Pipedrive
{
    public class RecentsFilters
    {
        public static RecentsFilters None
        {
            get { return new RecentsFilters(); }
        }

        public DateTime SinceWhen { get; set; }

        public RecentType? ItemType { get; set; }

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
                d.Add("since_timestamp", SinceWhen.ToString("yyyy-MM-dd HH:mm:ss"));

                if (ItemType.HasValue)
                {
                    d.Add("items", ItemType.Value.ToString());
                }

                return d;
            }
        }
    }
    public enum RecentItemsEnum {

    }
}
