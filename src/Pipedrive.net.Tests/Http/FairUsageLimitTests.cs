using System;
using System.Collections.Generic;
using Xunit;

namespace Pipedrive.Tests.Http
{
    public class FairUsageLimitTests
    {
        public class TheConstructor
        {
            [Fact]
            public void ParsesFairUsageLimitsFromHeaders()
            {
                var headers = new Dictionary<string, string>
                {
                    { "x-daily-requests-left", "981" }
                };

                var fairUsageLimit = new FairUsageLimit(headers);

                Assert.Equal(981, fairUsageLimit.DailyRequestsLeft);
            }

            [Fact]
            public void HandlesInvalidHeaderValues()
            {
                var headers = new Dictionary<string, string>
                {
                    { "x-daily-requests-left", "garbage" }
                };

                var fairUsageLimit = new FairUsageLimit(headers);

                Assert.Null(fairUsageLimit.DailyRequestsLeft);
            }

            [Fact]
            public void HandlesMissingHeaderValues()
            {
                var headers = new Dictionary<string, string>();

                var fairUsageLimit = new FairUsageLimit(headers);

                Assert.Null(fairUsageLimit.DailyRequestsLeft);
            }

            [Fact]
            public void EnsuresHeadersNotNull()
            {
                Assert.Throws<ArgumentNullException>(() => new FairUsageLimit((IDictionary<string, string>)null));
            }
        }

        public class TheMethods
        {
            [Fact]
            public void CanClone()
            {
                var original = new FairUsageLimit(981);

                var clone = original.Clone();

                Assert.NotSame(original, clone);
                Assert.Equal(original.DailyRequestsLeft, clone.DailyRequestsLeft);
            }
        }
    }
}
