using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class UsersClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new UsersClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new UsersClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<User>(Arg.Is<Uri>(u => u.ToString() == "users"));
                });
            }
        }

        public class TheGetByNameMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new UsersClient(connection);

                await client.GetByName("name");

                Received.InOrder(async () =>
                {
                    await connection.GetAll<User>(Arg.Is<Uri>(u => u.ToString() == "users/find"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                            && d["term"] == "name"
                            && d["search_by_email"] == "0"));
                });
            }
        }

        public class TheGetByEmailMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new UsersClient(connection);

                await client.GetByEmail("email");

                Received.InOrder(async () =>
                {
                    await connection.GetAll<User>(Arg.Is<Uri>(u => u.ToString() == "users/find"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                            && d["term"] == "email"
                            && d["search_by_email"] == "1"));
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new UsersClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<User>(Arg.Is<Uri>(u => u.ToString() == "users/123"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new UsersClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new UsersClient(connection);

                var newUser = new NewUser("name", "test@example.com", true);
                client.Create(newUser);

                connection.Received().Post<User>(Arg.Is<Uri>(u => u.ToString() == "users"),
                    Arg.Is<NewUser>(df => df.Name == "name"
                        && df.Email == "test@example.com"
                        && df.ActiveFlag == true));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new UsersClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new UsersClient(connection);

                var editUser = new UserUpdate { Name = "name", Email = "test@starwars.com", ActiveFlag = false };
                client.Edit(123, editUser);

                connection.Received().Put<User>(Arg.Is<Uri>(u => u.ToString() == "users/123"),
                    Arg.Is<UserUpdate>(df => df.Name == "name"
                        && df.Email == "test@starwars.com"
                        && df.ActiveFlag == false));
            }
        }
    }
}
