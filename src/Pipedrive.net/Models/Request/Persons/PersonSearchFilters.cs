using System.Collections.Generic;

namespace Pipedrive
{
    public class PersonSearchFilters
    {
        public static PersonSearchFilters None
        {
            get { return new PersonSearchFilters(); }
        }

        public PersonSearchField? Fields { get; set; }

        public bool? ExactMatch { get; set; }

        public long? OrganizationId { get; set; }

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
                if (Fields.HasValue)
                {
                    d.Add("fields", Fields.Value.ToString());
                }

                if (ExactMatch.HasValue)
                {
                    d.Add("exact_match", ExactMatch.Value.ToString());
                }

                if (OrganizationId.HasValue)
                {
                    d.Add("organization_id", OrganizationId.Value.ToString());
                }

                return d;
            }
        }
    }
}
