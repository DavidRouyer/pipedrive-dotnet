using System.Collections.Generic;
using System.Net;
using Pipedrive.Internal;
using Xunit;

namespace Pipedrive.Tests.Exceptions
{
    public class AbuseExceptionTests
    {
        public class TheConstructor
        {
            public class Message
            {
                [Fact]
                public void ContainsAbuseMessageFromApi()
                {
                    const string responseBody = "{\"error\":\"You have triggered an abuse detection mechanism. Please wait a few minutes before you try again.\"," +
                                                "\"error_info\":\"https://developer.github.com/v3/#abuse-rate-limits\"}";

                    var response = new Response(
                        HttpStatusCode.Forbidden,
                        responseBody,
                        new Dictionary<string, string>(),
                        "application/json");

                    var abuseException = new AbuseException(response);

                    Assert.Equal("You have triggered an abuse detection mechanism. Please wait a few minutes before you try again.", abuseException.ApiError.Error);
                }

                [Fact]
                public void HasDefaultMessage()
                {
                    var response = new Response(HttpStatusCode.Forbidden, null, new Dictionary<string, string>(), "application/json");
                    var abuseException = new AbuseException(response);

                    Assert.Equal("Request Forbidden - Abuse Detection", abuseException.Message);
                }
            }

            public class RetryAfterSeconds
            {
                public class HappyPath
                {
                    [Fact]
                    public void WithRetryAfterHeader_PopulatesRetryAfterSeconds()
                    {
                        var headerDictionary = new Dictionary<string, string> { { "Retry-After", "30" } };

                        var response = new Response(HttpStatusCode.Forbidden, null, headerDictionary, "application/json");
                        var abuseException = new AbuseException(response);

                        Assert.Equal(30, abuseException.RetryAfterSeconds);
                    }

                    [Fact]
                    public void WithZeroHeaderValue_RetryAfterSecondsIsZero()
                    {
                        var headerDictionary = new Dictionary<string, string> { { "Retry-After", "0" } };

                        var response = new Response(HttpStatusCode.Forbidden, null, headerDictionary, "application/json");
                        var abuseException = new AbuseException(response);

                        Assert.Equal(0, abuseException.RetryAfterSeconds);
                    }
                }

                public class UnhappyPaths
                {
                    [Fact]
                    public void NoRetryAfterHeader_RetryAfterSecondsIsSetToTheDefaultOfNull()
                    {
                        var headerDictionary = new Dictionary<string, string>();

                        var response = new Response(HttpStatusCode.Forbidden, null, headerDictionary, "application/json");
                        var abuseException = new AbuseException(response);

                        Assert.False(abuseException.RetryAfterSeconds.HasValue);
                    }

                    [Theory]
                    [InlineData(null)]
                    [InlineData("")]
                    [InlineData("    ")]
                    public void EmptyHeaderValue_RetryAfterSecondsDefaultsToNull(string emptyValueToTry)
                    {
                        var headerDictionary = new Dictionary<string, string> { { "Retry-After", emptyValueToTry } };

                        var response = new Response(HttpStatusCode.Forbidden, null, headerDictionary, "application/json");
                        var abuseException = new AbuseException(response);

                        Assert.False(abuseException.RetryAfterSeconds.HasValue);
                    }

                    [Fact]
                    public void NonParseableIntHeaderValue_RetryAfterSecondsDefaultsToNull()
                    {
                        var headerDictionary = new Dictionary<string, string> { { "Retry-After", "ABC" } };

                        var response = new Response(HttpStatusCode.Forbidden, null, headerDictionary, "application/json");
                        var abuseException = new AbuseException(response);

                        Assert.False(abuseException.RetryAfterSeconds.HasValue);
                    }

                    [Fact]
                    public void NegativeHeaderValue_RetryAfterSecondsDefaultsToNull()
                    {
                        var headerDictionary = new Dictionary<string, string> { { "Retry-After", "-123" } };

                        var response = new Response(HttpStatusCode.Forbidden, null, headerDictionary, "application/json");
                        var abuseException = new AbuseException(response);

                        Assert.False(abuseException.RetryAfterSeconds.HasValue);
                    }
                }
            }
        }
    }
}
