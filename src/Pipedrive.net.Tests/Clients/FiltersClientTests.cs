using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class FiltersClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new FiltersClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new FiltersClient(connection);

                await client.GetAll(FilterFilters.None);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Filter>(Arg.Is<Uri>(u => u.ToString() == "filters"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 0));
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new FiltersClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<Filter>(Arg.Is<Uri>(u => u.ToString() == "filters/123"));
                });
            }
        }
    }
}
