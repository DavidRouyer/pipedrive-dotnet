using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class OrganizationFieldsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new OrganizationFieldsClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationFieldsClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<OrganizationField>(Arg.Is<Uri>(u => u.ToString() == "organizationFields"));
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationFieldsClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<OrganizationField>(Arg.Is<Uri>(u => u.ToString() == "organizationFields/123"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationFieldsClient(connection);

                var newOrganizationField = new NewOrganizationField("name", FieldType.org);
                client.Create(newOrganizationField);

                connection.Received().Post<OrganizationField>(Arg.Is<Uri>(u => u.ToString() == "organizationFields"),
                    Arg.Is<NewOrganizationField>(df => df.Name == "name"
                        && df.FieldType == FieldType.org));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationFieldsClient(connection);

                var editOrganizationField = new OrganizationFieldUpdate { Name = "name", Options = "{}" };
                client.Edit(123, editOrganizationField);

                connection.Received().Put<OrganizationField>(Arg.Is<Uri>(u => u.ToString() == "organizationFields/123"),
                    Arg.Is<OrganizationFieldUpdate>(df => df.Name == "name"
                        && (string)df.Options == "{}"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationFieldsClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "organizationFields/123"));
            }
        }

        public class TheDeleteMultipleMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new OrganizationFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Delete(null));
            }

            [Fact]
            public async Task EnsuresNonEmptyArguments()
            {
                var client = new OrganizationFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentException>(() => client.Delete(new List<long>()));
            }

            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new OrganizationFieldsClient(connection);

                client.Delete(new List<long>() { 123, 456 });

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "organizationFields?ids=123,456"));
            }
        }
    }
}
