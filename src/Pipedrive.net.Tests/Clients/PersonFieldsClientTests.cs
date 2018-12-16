using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class PersonFieldsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new PersonFieldsClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PersonFieldsClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<PersonField>(Arg.Is<Uri>(u => u.ToString() == "personFields"));
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PersonFieldsClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<PersonField>(Arg.Is<Uri>(u => u.ToString() == "personFields/123"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new PersonFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PersonFieldsClient(connection);

                var newPersonField = new NewPersonField("name", FieldType.org);
                client.Create(newPersonField);

                connection.Received().Post<PersonField>(Arg.Is<Uri>(u => u.ToString() == "personFields"),
                    Arg.Is<NewPersonField>(df => df.Name == "name"
                        && df.FieldType == FieldType.org));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new PersonFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PersonFieldsClient(connection);

                var editPersonField = new PersonFieldUpdate { Name = "name", Options = "{}" };
                client.Edit(123, editPersonField);

                connection.Received().Put<PersonField>(Arg.Is<Uri>(u => u.ToString() == "personFields/123"),
                    Arg.Is<PersonFieldUpdate>(df => df.Name == "name"
                        && (string)df.Options == "{}"));
            }
        }
    }
}
