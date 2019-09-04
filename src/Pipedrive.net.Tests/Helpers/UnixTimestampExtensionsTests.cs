using System;
using Pipedrive.Helpers;
using Xunit;

namespace Pipedrive.Common
{
    public class UnixTimestampExtensionsTests
    {
        public class TheToUnixTimeMethod
        {
            [Fact]
            public void ReturnsUnixEpochCorrectly()
            {
                var epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
                Assert.Equal(0, epoch.ToUnixTime());
            }

            [Fact]
            public void ReturnsRandomDateCorrectly()
            {
                var epoch = new DateTimeOffset(1975, 1, 23, 1, 1, 1, TimeSpan.Zero);
                Assert.Equal(159670861, epoch.ToUnixTime());
            }
        }

        public class TheFromUnixTimeMethod
        {
            [Fact]
            public void ReturnsDateFromUnixEpochCorrectly()
            {
                var epoch = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);

                var result = 0L.FromUnixTime();

                Assert.Equal(epoch, result);
            }

            [Fact]
            public void ReturnsDateFromRandomTimeCorrectly()
            {
                var expected = new DateTimeOffset(1975, 1, 23, 1, 1, 2, TimeSpan.Zero);

                var result = 159670862L.FromUnixTime();

                Assert.Equal(expected, result);
            }
        }
    }
}
