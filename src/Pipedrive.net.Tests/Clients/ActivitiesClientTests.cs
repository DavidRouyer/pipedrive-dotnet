using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class ActivitiesClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new ActivitiesClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ActivitiesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ActivitiesClient(connection);

                var filters = new ActivityFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                    Done = ActivityDone.Done,
                };

                await client.GetAll(filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Activity>(
                        Arg.Is<Uri>(u => u.ToString() == "activities"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                                && d["user_id"] == "0"
                                && d["done"] == "1"),
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
                var client = new ActivitiesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAllForCurrent(null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ActivitiesClient(connection);

                var filters = new ActivityFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                    Done = ActivityDone.Done,
                };

                await client.GetAllForCurrent(filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Activity>(
                        Arg.Is<Uri>(u => u.ToString() == "activities"),
                        Arg.Is<Dictionary<string,string>>(d => d.Count == 1
                                && d["done"] == "1"),
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
                var client = new ActivitiesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAllForUserId(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ActivitiesClient(connection);

                var filters = new ActivityFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                    Done = ActivityDone.Done,
                };

                await client.GetAllForUserId(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Activity>(
                        Arg.Is<Uri>(u => u.ToString() == "activities"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                                && d["user_id"] == "123"
                                && d["done"] == "1"),
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
                var client = new ActivitiesClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<Activity>(Arg.Is<Uri>(u => u.ToString() == "activities/123"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ActivitiesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ActivitiesClient(connection);

                var newActivity = new NewActivity("subject", "type");
                client.Create(newActivity);

                connection.Received().Post<Activity>(Arg.Is<Uri>(u => u.ToString() == "activities"),
                    Arg.Is<NewActivity>(nc => nc.Subject == "subject"
                        && nc.Type == "type"));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ActivitiesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ActivitiesClient(connection);

                var editActivity = new ActivityUpdate { Subject = "subject", Type = "type" };
                client.Edit(123, editActivity);

                connection.Received().Put<Activity>(Arg.Is<Uri>(u => u.ToString() == "activities/123"),
                    Arg.Is<ActivityUpdate>(nc => nc.Subject == "subject"
                        && nc.Type == "type"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ActivitiesClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "activities/123"));
            }
        }
    }
}
