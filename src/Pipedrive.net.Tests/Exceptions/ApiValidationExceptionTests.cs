using System.Collections.Generic;
using System.Linq;
using System.Net;
using Pipedrive.Internal;
using Xunit;

namespace Pipedrive.Tests.Exceptions
{
    public class ApiValidationExceptionTests
    {
        public class TheConstructor
        {
            [Fact]
            public void CreatesGitHubErrorFromJsonResponse()
            {
                var response = new Response(
                    (HttpStatusCode)422,
                    @"{""errors"":[{""code"":""custom"",""field"":""key"",""message"":""key is " +
                    @"already in use"",""resource"":""PublicKey""}],""error"":""Validation Failed""}",
                    new Dictionary<string, string>(),
                    "application/json");

                var exception = new ApiValidationException(response);

                Assert.Equal("Validation Failed", exception.ApiError.Error);
            }

            [Fact]
            public void ProvidesDefaultMessage()
            {
                var response = new Response((HttpStatusCode)422, null, new Dictionary<string, string>(), "application/json");

                var exception = new ApiValidationException(response);

                Assert.Equal("Validation Failed", exception.Message);
            }
        }
    }
}
