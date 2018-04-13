using System.Collections.Generic;
using System.Net;
using Pipedrive.Internal;
using Xunit;

namespace Pipedrive.Tests.Exceptions
{
    public class ForbiddenExceptionTests
    {
        public class TheConstructor
        {
            [Fact]
            public void IdentifiesMaxLoginAttemptsExceededReason()
            {
                const string responseBody = "{\"error\":\"YOU SHALL NOT PASS!\"," +
                                            "\"error_info\":\"http://developer.github.com/v3\"}";
                var response = new Response(
                    HttpStatusCode.Forbidden,
                    responseBody,
                    new Dictionary<string, string>(),
                    "application/json");
                var forbiddenException = new ForbiddenException(response);

                Assert.Equal("YOU SHALL NOT PASS!", forbiddenException.ApiError.Error);
            }

            [Fact]
            public void HasDefaultMessage()
            {
                var response = new Response(HttpStatusCode.Forbidden, null, new Dictionary<string, string>(), "application/json");
                var forbiddenException = new ForbiddenException(response);

                Assert.Equal("Request Forbidden", forbiddenException.Message);
            }
        }
    }
}
