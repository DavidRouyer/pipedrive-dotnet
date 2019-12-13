using System;

namespace Pipedrive.CustomFields
{
    public class DateRangeCustomField : ICustomField
    {
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateRangeCustomField(DateTime? startDate, DateTime? endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
