using System;

namespace Pipedrive.CustomFields
{
    public class TimeCustomField : ICustomField
    {
        public TimeSpan Value { get; set; }

        public int TimezoneId { get; set; }

        public TimeCustomField(TimeSpan value, int timezoneId)
        {
            Value = value;
            TimezoneId = timezoneId;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
