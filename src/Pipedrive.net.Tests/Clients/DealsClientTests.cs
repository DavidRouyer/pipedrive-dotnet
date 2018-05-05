using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class DealsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new DealsClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetAll(filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Deal>(
                        Arg.Is<Uri>(u => u.ToString() == "deals"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                                && d["owned_by_you"] == "0"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0)
                        );
                });
            }
        }

        public class TheGetAllForCurrentMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAllForCurrent(null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetAllForCurrent(filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Deal>(
                        Arg.Is<Uri>(u => u.ToString() == "deals"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                                && d["owned_by_you"] == "1"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0)
                        );
                });
            }
        }

        public class TheGetForUserIdMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAllForUserId(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetAllForUserId(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Deal>(
                        Arg.Is<Uri>(u => u.ToString() == "deals"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                                && d["user_id"] == "123"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0)
                        );
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<Deal>(Arg.Is<Uri>(u => u.ToString() == "deals/123"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var newDeal = new NewDeal("title");
                client.Create(newDeal);

                connection.Received().Post<Deal>(Arg.Is<Uri>(u => u.ToString() == "deals"),
                    Arg.Is<NewDeal>(d => d.Title == "title"));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var editDeal = new DealUpdate { Title = "title" };
                client.Edit(123, editDeal);

                connection.Received().Put<Deal>(Arg.Is<Uri>(u => u.ToString() == "deals/123"),
                    Arg.Is<DealUpdate>(d => d.Title == "title"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "deals/123"));
            }
        }

        public class TheGetUpdatesMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetUpdates(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealUpdateFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetUpdates(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<DealUpdateFlow>(
                        Arg.Is<Uri>(u => u.ToString() == "deals/123/flow"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                            && d["id"] == "123"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0)
                        );
                });
            }
        }

        public class TheGetFollowersMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                await client.GetFollowers(123);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Follower>(
                        Arg.Is<Uri>(u => u.ToString() == "deals/123/followers"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                            && d["id"] == "123")
                        );
                });
            }
        }

        public class TheGetActivitiesMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetActivities(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealActivityFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetActivities(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Activity>(
                        Arg.Is<Uri>(u => u.ToString() == "deals/123/activities"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                            && d["id"] == "123"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0)
                        );
                });
            }
        }
    }
}
