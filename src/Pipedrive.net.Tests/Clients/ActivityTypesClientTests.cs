using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class ActivityTypesClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new ActivityTypesClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ActivityTypesClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<ActivityType>(Arg.Is<Uri>(u => u.ToString() == "activityTypes"));
                });
            }
        }
    }
}
