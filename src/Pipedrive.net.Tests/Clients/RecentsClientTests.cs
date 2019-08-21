using NSubstitute;
using Pipedrive.CustomFields;
using Pipedrive.Models.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using static Pipedrive.DealsClient;

namespace Pipedrive.Tests.Clients
{
    public class RecentsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new RecentsClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new RecentsClient(connection);

                var filters = new RecentsFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                    SinceWhen = new DateTime(2018,1,1, 13,23,12)
                };

                await client.GetAll(filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Recents>(
                        Arg.Is<Uri>(u => u.ToString() == "recents"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                                && d["since_timestamp"] == "2018-01-01 13:23:12"
                                ),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0)
                        );
                });
            }
            [Fact]
            public async Task RequestsCorrectUrlForDeals()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new RecentsClient(connection);

                var filters = new RecentsFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                    ItemType = RecentType.deal,
                    SinceWhen = new DateTime(2018, 1, 1, 13, 23, 12)
                };

                await client.GetAll(filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Recents>(
                        Arg.Is<Uri>(u => u.ToString() == "recents"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                                && d["since_timestamp"] == "2018-01-01 13:23:12"
                                && d["items"] == "deal"
                                ),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0)
                        );
                });
            }
        }

    }
}
