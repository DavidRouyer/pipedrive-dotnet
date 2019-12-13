using System;
using System.Collections.Generic;
using System.Net;
using Pipedrive.Helpers;
using Pipedrive.Internal;
using Xunit;

namespace Pipedrive.Tests.Exceptions
{
    public class RateLimitExceededExceptionTests
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
                    { "X-RateLimit-Reset", "49" }
                };
                var response = new Response(HttpStatusCode.Forbidden, null, headers, "application/json");

                var exception = new RateLimitExceededException(response);

                Assert.Equal(HttpStatusCode.Forbidden, exception.StatusCode);
                Assert.Equal(100, exception.Limit);
                Assert.Equal(42, exception.Remaining);
                var expectedReset = DateTime.UtcNow.CeilingSecond().AddSeconds(49);
                Assert.Equal("API Rate Limit exceeded", exception.Message);
                Assert.Equal(expectedReset, exception.Reset);
            }

            [Fact]
            public void HandlesInvalidHeaderValues()
            {
                var headers = new Dictionary<string, string>
                {
                    { "X-RateLimit-Limit", "XXX" },
                    { "X-RateLimit-Remaining", "XXXX" },
                    { "X-RateLimit-Reset", "XXXX" }
                };
                var response = new Response(HttpStatusCode.Forbidden, null, headers, "application/json");

                var exception = new RateLimitExceededException(response);

                Assert.Equal(HttpStatusCode.Forbidden, exception.StatusCode);
                Assert.Equal(0, exception.Limit);
                Assert.Equal(0, exception.Remaining);
                var expectedReset = new DateTimeOffset(DateTime.UtcNow.CeilingSecond());
                Assert.Equal(expectedReset, exception.Reset);
            }

            [Fact]
            public void HandlesMissingHeaderValues()
            {
                var response = new Response(HttpStatusCode.Forbidden, null, new Dictionary<string, string>(), "application/json");
                var exception = new RateLimitExceededException(response);

                Assert.Equal(HttpStatusCode.Forbidden, exception.StatusCode);
                Assert.Equal(0, exception.Limit);
                Assert.Equal(0, exception.Remaining);
                var expectedReset = new DateTimeOffset(DateTime.UtcNow.CeilingSecond());
                Assert.Equal(expectedReset, exception.Reset);
            }
        }
    }
}
