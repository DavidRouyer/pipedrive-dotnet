using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class CurrenciesClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new CurrenciesClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new CurrenciesClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Currency>(Arg.Is<Uri>(u => u.ToString() == "currencies"));
                });
            }

            [Fact]
            public async Task RequestsCorrectUrlWithTerm()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new CurrenciesClient(connection);

                await client.GetAll("fake");

                Received.InOrder(async () =>
                {
                    await connection
                        .GetAll<Currency>(
                            Arg.Is<Uri>(u => u.ToString() == "currencies"),
                            Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                                && d["term"] == "fake"));
                });
            }
        }
    }
}
