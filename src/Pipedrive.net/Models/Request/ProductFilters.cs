using System.Collections.Generic;

namespace Pipedrive.Models.Request
{
    public class ProductFilters
    {
        public static ProductFilters None => new ProductFilters();

        public int? StartPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

        public int? UserId { get; set; }

        public long? FilterId { get; set; }

        public string FirstCharacter { get; set; }

        public IDictionary<string, string> Parameters
        {
            get
            {
                var d = new Dictionary<string, string>();
                if (UserId.HasValue)
                {
                    d.Add("user_id", UserId.Value.ToString());
                }

                if (FilterId.HasValue)
                {
                    d.Add("filter_id", FilterId.Value.ToString());
                }

                if (!string.IsNullOrWhiteSpace(FirstCharacter))
                {
                    d.Add("first_char", FirstCharacter);
                }

                return d;
            }
        }
    }
}
