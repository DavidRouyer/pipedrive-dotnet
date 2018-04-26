using System;

namespace Pipedrive.CustomFields
{
    public class TimeField : IField
    {
        public TimeSpan Value { get; set; }

        public int TimezoneId { get; set; }

        public TimeField(TimeSpan value, int timezoneId)
        {
            Value = value;
            TimezoneId = timezoneId;
        }
    }
}
