using System;

namespace Pipedrive.CustomFields
{
    public class TimeRangeCustomField : ICustomField
    {
        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public int TimezoneId { get; set; }

        public TimeRangeCustomField(TimeSpan startTime, TimeSpan endTime, int timezoneId)
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
