using Pipedrive.Internal;
using Xunit;

namespace Pipedrive.Tests.Http
{
    public class RequestTests
    {
        public class TheConstructor
        {
            [Fact]
            public void InitializesAllRequiredProperties()
            {
                var r = new Request();

                Assert.NotNull(r.Headers);
            }
        }
    }
}
