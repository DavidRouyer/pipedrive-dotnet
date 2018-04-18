using System;

namespace Pipedrive
{
    public class TimeRangeField : IField
    {
        public TimeSpan StartTime {get; set; }

        public TimeSpan EndTime { get; set; }

        public int TimezoneId { get; set; }

        public TimeRangeField(TimeSpan startTime, TimeSpan endTime, int timezoneId)
        {
            StartTime = startTime;
            EndTime = endTime;
            TimezoneId = timezoneId;
        }
    }
}
