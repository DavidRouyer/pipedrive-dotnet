using System;
using Pipedrive.Helpers;
using Xunit;

namespace Pipedrive.Common
{
    public class DateTimeExtensionsTests
    {
        public class CeilingSecond
        {
            [Fact]
            public void ReturnsCurrentTimeIfDateTimeIsExactlyOnSecond()
            {
                var dateTime = new DateTime(2019, 08, 08, 18, 02, 13, DateTimeKind.Utc);
                Assert.Equal(dateTime, dateTime.CeilingSecond());
            }

            [Fact]
            public void ReturnsNextSecondIfDateTimeHasLessThan500Milliseconds()
            {
                var dateTime = new DateTime(2019, 08, 08, 18, 02, 13, DateTimeKind.Utc);
                var dateTimeWithNonZeroMilliseconds = dateTime.AddTicks(987);
                var expectedDateTime = new DateTime(2019, 08, 08, 18, 02, 14, DateTimeKind.Utc);
                Assert.Equal(expectedDateTime, dateTimeWithNonZeroMilliseconds.CeilingSecond());
            }

            [Fact]
            public void ReturnsNextSecondIfDateTimeHasMoreThan500Milliseconds()
            {
                var dateTime = new DateTime(2019, 08, 08, 18, 02, 13, DateTimeKind.Utc);
                var dateTimeWithNonZeroMilliseconds = dateTime.AddTicks(6153458);
                var expectedDateTime = new DateTime(2019, 08, 08, 18, 02, 14, DateTimeKind.Utc);
                Assert.Equal(expectedDateTime, dateTimeWithNonZeroMilliseconds.CeilingSecond());
            }
        }
    }
}
