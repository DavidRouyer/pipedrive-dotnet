using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class DealFieldsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new DealFieldsClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealFieldsClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<DealField>(Arg.Is<Uri>(u => u.ToString() == "dealFields"));
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealFieldsClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<DealField>(Arg.Is<Uri>(u => u.ToString() == "dealFields/123"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealFieldsClient(connection);

                var newDealField = new NewDealField("name", FieldType.org);
                client.Create(newDealField);

                connection.Received().Post<DealField>(Arg.Is<Uri>(u => u.ToString() == "dealFields"),
                    Arg.Is<NewDealField>(df => df.Name == "name"
                        && df.FieldType == FieldType.org));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealFieldsClient(connection);

                var editDealField = new DealFieldUpdate { Name = "name", Options = "{}" };
                client.Edit(123, editDealField);

                connection.Received().Put<DealField>(Arg.Is<Uri>(u => u.ToString() == "dealFields/123"),
                    Arg.Is<DealFieldUpdate>(df => df.Name == "name"
                        && (string)df.Options == "{}"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealFieldsClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "dealFields/123"));
            }
        }

        public class TheDeleteMultipleMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Delete(null));
            }

            [Fact]
            public async Task EnsuresNonEmptyArguments()
            {
                var client = new DealFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentException>(() => client.Delete(new List<long>()));
            }

            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealFieldsClient(connection);

                client.Delete(new List<long>() { 123, 456 });

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "dealFields?ids=123,456"));
            }
        }
    }
}
