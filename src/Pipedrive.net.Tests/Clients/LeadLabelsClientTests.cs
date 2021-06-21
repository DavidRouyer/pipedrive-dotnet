using System;
using System.Security.Cryptography;
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
                Assert.Throws<ArgumentNullException>(() => new LeadLabelClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new LeadLabelClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<LeadLabel>(
                        Arg.Is<Uri>(u => u.ToString() == "leadLabels"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new LeadLabelClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(new NewLeadLabel()));
                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(new NewLeadLabel { Name = "name" }));
                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(new NewLeadLabel { Color = "color" }));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new LeadLabelClient(connection);

                client.Create(new NewLeadLabel
                {
                    Name = "name",
                    Color = "color"
                });

                connection.Received().Post<LeadLabel>(Arg.Is<Uri>(u => u.ToString() == "leadLabels"),
                    Arg.Is<NewLeadLabel>(ll => ll.Name == "name" && ll.Color == "color"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new LeadLabelClient(connection);
                var guid = Guid.NewGuid();

                client.Delete(guid);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == $"leadLabels/{guid}"));
            }
        }
    }
}
