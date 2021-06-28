using System;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class LeadLabelsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new LeadLabelsClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new LeadLabelsClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<LeadLabel>(Arg.Is<Uri>(u => u.ToString() == "leadLabels"));
                });
            }
        }
    }
}
