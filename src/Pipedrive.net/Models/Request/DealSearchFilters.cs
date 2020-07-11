using System.Collections.Generic;

namespace Pipedrive
{
    public class DealSearchFilters
    {
        public static DealSearchFilters None
        {
            get { return new DealSearchFilters(); }
        }

        public bool? ExactMatch { get; set; }

        public long? PersonId { get; set; }

        public long? OrganizationId { get; set; }

        public DealStatus? Status { get; set; }

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
                if (ExactMatch.HasValue)
                {
                    d.Add("exact_match", ExactMatch.Value.ToString());
                }

                if (PersonId.HasValue)
                {
                    d.Add("person_id", PersonId.Value.ToString());
                }

                if (OrganizationId.HasValue)
                {
                    d.Add("organization_id", OrganizationId.Value.ToString());
                }

                if (Status.HasValue)
                {
                    d.Add("status", Status.Value.ToString());
                }

                return d;
            }
        }
    }
}
