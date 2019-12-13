using System;

namespace Pipedrive.Helpers
{
    public static class DateTimeExtensions
    {
        public static DateTime CeilingSecond(this DateTime dateTime)
        {
            if (dateTime.Ticks % 10000000 == 0) return dateTime;
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Kind).AddSeconds(1);
        }
    }
}
