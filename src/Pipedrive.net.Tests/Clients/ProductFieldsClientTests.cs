using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class ProductFieldsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new ProductFieldsClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductFieldsClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<ProductField>(Arg.Is<Uri>(u => u.ToString() == "productFields"));
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductFieldsClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<ProductField>(Arg.Is<Uri>(u => u.ToString() == "productFields/123"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ProductFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductFieldsClient(connection);

                var newProductField = new NewProductField("name", FieldType.org);
                client.Create(newProductField);

                connection.Received().Post<ProductField>(Arg.Is<Uri>(u => u.ToString() == "productFields"),
                    Arg.Is<NewProductField>(df => df.Name == "name"
                        && df.FieldType == FieldType.org));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ProductFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductFieldsClient(connection);

                var editProductField = new ProductFieldUpdate { Name = "name", Options = "{}" };
                client.Edit(123, editProductField);

                connection.Received().Put<ProductField>(Arg.Is<Uri>(u => u.ToString() == "productFields/123"),
                    Arg.Is<ProductFieldUpdate>(df => df.Name == "name"
                        && (string)df.Options == "{}"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductFieldsClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "productFields/123"));
            }
        }

        public class TheDeleteMultipleMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ProductFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Delete(null));
            }

            [Fact]
            public async Task EnsuresNonEmptyArguments()
            {
                var client = new ProductFieldsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentException>(() => client.Delete(new List<long>()));
            }

            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductFieldsClient(connection);

                client.Delete(new List<long>() { 123, 456 });

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "productFields?ids=123,456"));
            }
        }
    }
}
