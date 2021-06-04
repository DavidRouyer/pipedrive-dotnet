using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class OrganizationsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new OrganizationsClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                var filters = new OrganizationFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetAll(filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Organization>(
                        Arg.Is<Uri>(u => u.ToString() == "organizations"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 0),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
            }
        }

        public class TheGetForUserIdMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAllForUserId(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                var filters = new OrganizationFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetAllForUserId(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Organization>(
                        Arg.Is<Uri>(u => u.ToString() == "organizations"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                                && d["user_id"] == "123"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
            }
        }

        public class TheSearchMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Search(null, null));
            }

            [Fact]
            public async Task EnsuresSearchTermIsMoreThan2Characters()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                var exception = await Assert.ThrowsAsync<ArgumentException>(() => client.Search("p", OrganizationSearchFilters.None));
                Assert.Equal("The search term must have at least 2 characters (Parameter 'term')", exception.Message);
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                var filters = new OrganizationSearchFilters
                {
                    ExactMatch = true,
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.Search("name", filters);

                Received.InOrder(async () =>
                {
                    await connection.SearchAll<SearchResult<SimpleOrganization>>(Arg.Is<Uri>(u => u.ToString() == "organizations/search"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                            && d["term"] == "name"
                            && d["exact_match"] == "True"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<Organization>(Arg.Is<Uri>(u => u.ToString() == "organizations/123"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                var newOrganization = new NewOrganization("name");
                client.Create(newOrganization);

                connection.Received().Post<Organization>(Arg.Is<Uri>(u => u.ToString() == "organizations"),
                    Arg.Is<NewOrganization>(d => d.Name == "name"));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                var editOrganization = new OrganizationUpdate { Name = "name" };
                client.Edit(123, editOrganization);

                connection.Received().Put<Organization>(Arg.Is<Uri>(u => u.ToString() == "organizations/123"),
                    Arg.Is<OrganizationUpdate>(d => d.Name == "name"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "organizations/123"));
            }
        }

        public class TheDeleteMultipleMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Delete(null));
            }

            [Fact]
            public async Task EnsuresNonEmptyArguments()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentException>(() => client.Delete(new List<long>()));
            }

            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                client.Delete(new List<long>() { 123, 456 });

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "organizations?ids=123,456"));
            }
        }

        public class TheGetDealsMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetDeals(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                var filters = new OrganizationDealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetDeals(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Deal>(
                        Arg.Is<Uri>(u => u.ToString() == "organizations/123/deals"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                            && d["id"] == "123"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
            }
        }

        public class TheGetPersonsMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetPersons(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                var filters = new OrganizationFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetPersons(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Person>(
                        Arg.Is<Uri>(u => u.ToString() == "organizations/123/persons"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                            && d["id"] == "123"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
            }
        }

        public class TheGetFollowersMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                await client.GetFollowers(123);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<OrganizationFollower>(
                        Arg.Is<Uri>(u => u.ToString() == "organizations/123/followers"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                            && d["id"] == "123"));
                });
            }
        }

        public class TheAddFollowerMethod
        {
            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                client.AddFollower(1, 2);

                connection.Received().Post<OrganizationFollower>(Arg.Is<Uri>(u => u.ToString() == "organizations/1/followers"),
                    Arg.Is<object>(o => o.ToString() == new { user_id = 2 }.ToString()));
            }
        }

        public class TheDeleteFollowerMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                client.DeleteFollower(1, 461);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "organizations/1/followers/461"));
            }
        }

        public class TheGetActivitiesMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetActivities(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                var filters = new OrganizationActivityFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                    Done = ActivityDone.Done,
                };

                await client.GetActivities(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<DealActivity>(
                        Arg.Is<Uri>(u => u.ToString() == "organizations/123/activities"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                            && d["id"] == "123"
                            && d["done"] == "1"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
            }
        }

        public class TheGetFilesMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetFiles(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                var filters = new OrganizationFileFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetFiles(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<File>(
                        Arg.Is<Uri>(u => u.ToString() == "organizations/123/files"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                            && d["id"] == "123"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
            }
        }

        public class TheGetUpdatesMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetUpdates(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationsClient(connection);

                var filters = new OrganizationUpdateFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetUpdates(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<EntityUpdateFlow>(
                        Arg.Is<Uri>(u => u.ToString() == "organizations/123/flow"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                            && d["id"] == "123"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
            }
        }
    }
}
