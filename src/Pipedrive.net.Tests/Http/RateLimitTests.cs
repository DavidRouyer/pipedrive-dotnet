using System;
using System.Collections.Generic;
using Pipedrive.Helpers;
using Xunit;

namespace Pipedrive.Tests.Http
{
    public class RateLimitTests
    {
        public class TheConstructor
        {
            [Fact]
            public void ParsesRateLimitsFromHeaders()
            {
                var headers = new Dictionary<string, string>
                {
                    { "X-RateLimit-Limit", "100" },
                    { "X-RateLimit-Remaining", "42" },
                    { "X-RateLimit-Reset", "779" }
                };

                var rateLimit = new RateLimit(headers);

                Assert.Equal(100, rateLimit.Limit);
                Assert.Equal(42, rateLimit.Remaining);
                var expectedReset = new DateTimeOffset(DateTime.UtcNow.CeilingSecond().AddSeconds(779));
                Assert.Equal(expectedReset, rateLimit.Reset);
            }

            [Fact]
            public void HandlesInvalidHeaderValues()
            {
                var headers = new Dictionary<string, string>
                {
                    { "X-RateLimit-Limit", "1234scoobysnacks1234" },
                    { "X-RateLimit-Remaining", "xanadu" },
                    { "X-RateLimit-Reset", "garbage" }
                };

                var rateLimit = new RateLimit(headers);

                Assert.Equal(0, rateLimit.Limit);
                Assert.Equal(0, rateLimit.Remaining);
                var expectedReset = new DateTimeOffset(DateTime.UtcNow.CeilingSecond());
                Assert.Equal(expectedReset, rateLimit.Reset);
            }

            [Fact]
            public void HandlesMissingHeaderValues()
            {
                var headers = new Dictionary<string, string>();

                var rateLimit = new RateLimit(headers);

                Assert.Equal(0, rateLimit.Limit);
                Assert.Equal(0, rateLimit.Remaining);
                var expectedReset = new DateTimeOffset(DateTime.UtcNow.CeilingSecond());
                Assert.Equal(expectedReset, rateLimit.Reset);
            }

            [Fact]
            public void EnsuresHeadersNotNull()
            {
                Assert.Throws<ArgumentNullException>(() => new RateLimit(null));
            }
        }

        public class TheMethods
        {
            [Fact]
            public void CanClone()
            {
                var original = new RateLimit(100, 42, 449);

                var clone = original.Clone();

                // Note the use of Assert.NotSame tests for value types - this should continue to test should the underlying
                // model are changed to Object types
                Assert.NotSame(original, clone);
                Assert.Equal(original.Limit, clone.Limit);
                Assert.Equal(original.Remaining, clone.Remaining);
                Assert.Equal(original.ResetInSeconds, clone.ResetInSeconds);
                Assert.Equal(original.Reset, clone.Reset);
            }
        }
    }
}
