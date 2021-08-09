using System;
using System.Collections.Generic;
using System.Text;

namespace Pipedrive.Models.Request.Recents
{
    public class RecentFilters
    {
        public DateTime Since { get; set; }
        public List<RecentItem> RecentItems { get; set; }
        public int? StartPage { get; set; }
        public int? PageCount { get; set; }
        public int? PageSize { get; set; }
        public IDictionary<string, string> Parameters
        {
            get
            {
                var d = new Dictionary<string, string>();
                foreach (var item in RecentItems)
                {
                    d.Add("items", item.ToString());
                }
                d.Add("since_timestamp", Since.ToString("yyyy-MM-dd HH:mm:ss"));
                return d;
            }
        }
    }
}
