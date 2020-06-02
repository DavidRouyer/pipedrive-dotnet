using System;
using System.Collections.Generic;

namespace Pipedrive
{
    public class NoteFilters
    {
        public static NoteFilters None
        {
            get { return new NoteFilters(); }
        }

        public long? UserId { get; set; }

        public long? DealId { get; set; }

        public long? PersonId { get; set; }

        public long? OrgId { get; set; }

        public int? StartPage { get; set; }

        public int? PageCount { get; set; }

        public int? PageSize { get; set; }

        public string Sort { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public long? PinnedToDealFlag { get; set; }

        public long? PinnedToOrganizationFlag { get; set; }

        public long? PinnedToPersonFlag { get; set; }

        /// <summary>
        /// Get the query parameters that will be appending onto the search
        /// </summary>
        public IDictionary<string, string> Parameters
        {
            get
            {
                var d = new Dictionary<string, string>();
                if (UserId.HasValue)
                {
                    d.Add("user_id", UserId.Value.ToString());
                }

                if (DealId.HasValue)
                {
                    d.Add("deal_id", DealId.Value.ToString());
                }

                if (PersonId.HasValue)
                {
                    d.Add("person_id", PersonId.Value.ToString());
                }

                if (OrgId.HasValue)
                {
                    d.Add("org_id", OrgId.Value.ToString());
                }

                if (!string.IsNullOrWhiteSpace(Sort))
                {
                    d.Add("sort", Sort);
                }

                if (StartDate.HasValue)
                {
                    d.Add("start_date", StartDate.Value.ToString());
                }

                if (EndDate.HasValue)
                {
                    d.Add("end_date", EndDate.Value.ToString());
                }

                if (PinnedToDealFlag.HasValue)
                {
                    d.Add("pinned_to_deal_flag", PinnedToDealFlag.Value.ToString());
                }

                if (PinnedToOrganizationFlag.HasValue)
                {
                    d.Add("pinned_to_organization_flag", PinnedToOrganizationFlag.Value.ToString());
                }

                if (PinnedToPersonFlag.HasValue)
                {
                    d.Add("pinned_to_person_flag", PinnedToPersonFlag.Value.ToString());
                }

                return d;
            }
        }
    }
}
