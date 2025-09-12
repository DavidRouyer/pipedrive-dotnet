using System;

namespace Pipedrive.CustomFields
{
    public class TimeRangeCustomField : ICustomField
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public TimeSpan TimezoneId { get; set; }

        public TimeRangeCustomField(TimeSpan startTime, TimeSpan endTime, TimeSpan timezoneId)
        {
            StartTime = startTime;
            EndTime = endTime;
            TimezoneId = timezoneId;
        }

        public override string ToString()
        {
            return $"{StartTime} to {EndTime}";
        }
    }
}
