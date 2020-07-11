﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Pipedrive.Models.Request;
using Pipedrive.Models.Response;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class PersonsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new PersonsClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new PersonsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PersonsClient(connection);

                var filters = new PersonFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetAll(filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Person>(
                        Arg.Is<Uri>(u => u.ToString() == "persons"),
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
                var client = new PersonsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAllForUserId(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PersonsClient(connection);

                var filters = new PersonFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetAllForUserId(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Person>(
                        Arg.Is<Uri>(u => u.ToString() == "persons"),
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
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PersonsClient(connection);

                var filters = new PersonSearchFilters
                {
                    ExactMatch = true,
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.Search("name", filters);

                Received.InOrder(async () =>
                {
                    await connection.SearchAll<SearchResult<SimplePerson>>(Arg.Is<Uri>(u => u.ToString() == "persons/search"),
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
                var client = new PersonsClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<Person>(Arg.Is<Uri>(u => u.ToString() == "persons/123"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new PersonsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PersonsClient(connection);

                var newPerson = new NewPerson("name");
                client.Create(newPerson);

                connection.Received().Post<Person>(Arg.Is<Uri>(u => u.ToString() == "persons"),
                    Arg.Is<NewPerson>(d => d.Name == "name"));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new PersonsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PersonsClient(connection);

                var editPerson = new PersonUpdate { Name = "name" };
                client.Edit(123, editPerson);

                connection.Received().Put<Person>(Arg.Is<Uri>(u => u.ToString() == "persons/123"),
                    Arg.Is<PersonUpdate>(d => d.Name == "name"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PersonsClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "persons/123"));
            }
        }

        public class TheGetDealsMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new PersonsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetDeals(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PersonsClient(connection);

                var filters = new PersonDealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetDeals(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Deal>(
                        Arg.Is<Uri>(u => u.ToString() == "persons/123/deals"),
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
                var client = new PersonsClient(connection);

                await client.GetFollowers(123);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<PersonFollower>(
                        Arg.Is<Uri>(u => u.ToString() == "persons/123/followers"),
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
                var client = new PersonsClient(connection);

                client.AddFollower(1, 2);

                connection.Received().Post<PersonFollower>(Arg.Is<Uri>(u => u.ToString() == "persons/1/followers"),
                    Arg.Is<object>(o => o.ToString() == new { user_id = 2 }.ToString()));
            }
        }

        public class TheDeleteFollowerMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PersonsClient(connection);

                client.DeleteFollower(1, 461);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "persons/1/followers/461"));
            }
        }
    }
}
