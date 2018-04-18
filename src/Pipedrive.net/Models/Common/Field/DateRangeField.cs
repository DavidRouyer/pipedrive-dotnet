using System;

namespace Pipedrive
{
    public class DateRangeField : IField
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateRangeField(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
