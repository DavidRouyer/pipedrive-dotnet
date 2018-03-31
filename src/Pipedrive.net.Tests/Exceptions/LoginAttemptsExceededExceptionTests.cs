using Pipedrive.Internal;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Pipedrive.Tests.Exceptions
{
    public class LoginAttemptsExceededExceptionTests
    {
        public class TheConstructor
        {
            [Fact]
            public void SetsDefaultMessage()
            {
                var response = new Response(HttpStatusCode.Forbidden, null, new Dictionary<string, string>(), "application/json");

                var exception = new LoginAttemptsExceededException(response);

                Assert.Equal("Maximum number of login attempts exceeded", exception.Message);
            }
        }
    }
}
