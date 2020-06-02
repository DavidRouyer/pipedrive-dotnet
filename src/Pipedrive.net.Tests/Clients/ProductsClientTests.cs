using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Pipedrive.Clients;
using Pipedrive.CustomFields;
using Pipedrive.Models.Request;
using Pipedrive.Models.Response;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class ProductsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new ProductsClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ProductsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                var filters = new ProductFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0
                };

                await client.GetAll(filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Product>(
                        Arg.Is<Uri>(u => u.ToString() == "products"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 0),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                                && o.PageCount == 1
                                                && o.StartPage == 0));
                });
            }
        }

        public class TheGetByNameMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ProductsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetByName(null, null));
            }

            [Fact]
            public async Task EnsuresSearchTermIsMoreThan3Characters()
            {
                var client = new ProductsClient(Substitute.For<IApiConnection>());

                var exception = await Assert.ThrowsAsync<Exception>(() => client.GetByName("pr", null));
                Assert.Equal("searchTerm must be a minimum of 3 characters in length", exception.Message);
            }

            [Fact]
            public async Task RequestsCorrectUrlWithOneParameter()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                await client.GetByName("product");

                Received.InOrder(async () =>
                {
                    await connection.GetAll<SimpleProduct>(Arg.Is<Uri>(u => u.ToString() == "products/find"),
                                                           Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                                                                                                && d["term"] == "product"));
                });
            }

            [Fact]
            public async Task RequestsCorrectUrlWithTwoParameters()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                await client.GetByName("product", "EUR");

                Received.InOrder(async () =>
                {
                    await connection.GetAll<SimpleProduct>(Arg.Is<Uri>(u => u.ToString() == "products/find"),
                                                           Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                                                                                                && d["term"] == "product"
                                                                                                && d["currency"] == "EUR"));
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<Product>(Arg.Is<Uri>(u => u.ToString() == "products/123"));
                });
            }
        }

        public class TheGetDealsForProductMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                await client.GetDealsForProduct(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<IReadOnlyList<Deal>>(Arg.Is<Uri>(u => u.ToString() == "products/123/deals"));
                });
            }
        }

        public class TheGetFilesForProductMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                await client.GetFilesForProduct(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<IReadOnlyList<File>>(Arg.Is<Uri>(u => u.ToString() == "products/123/files"));
                });
            }
        }

        public class TheGetFollowersForProductMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                await client.GetFollowersForProduct(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<IReadOnlyList<ProductFollower>>(Arg.Is<Uri>(u => u.ToString() == "products/123/followers"));
                });
            }
        }

        public class TheGetPermittedUsersMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                await client.GetPermittedUsers(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<IReadOnlyList<long>>(Arg.Is<Uri>(u => u.ToString() == "products/123/permittedUsers"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ProductsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public async Task PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                var newProduct = new NewProduct("name");
                var customFields = new Dictionary<string, ICustomField>() { { "5913c8efdcf5c641a516d1fbd498235544b1b195", new LongCustomField(123) } };
                newProduct.CustomFields = customFields;
                await client.Create(newProduct);

                Received.InOrder(async () =>
                {
                    await connection.Post<Product>(Arg.Is<Uri>(u => u.ToString() == "products"),
                                                   Arg.Is<NewProduct>(d => d.Name == "name" && d.CustomFields == customFields));
                });
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ProductsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public async Task PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                var customFields = new Dictionary<string, ICustomField>() { { "5913c8efdcf5c641a516d1fbd498235544b1b195", new LongCustomField(123) } };
                var editProduct = new ProductUpdate { Name = "new product name", CustomFields = customFields };
                await client.Edit(123, editProduct);

                Received.InOrder(async () =>
                {
                    await connection.Put<UpdatedProduct>(Arg.Is<Uri>(u => u.ToString() == "products/123"),
                                                         Arg.Is<ProductUpdate>(d => d.Name == "new product name" && d.CustomFields == customFields));
                });
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public async Task DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                await client.Delete(123);

                Received.InOrder(async () =>
                {
                    await connection.Delete(Arg.Is<Uri>(u => u.ToString() == "products/123"));
                });
            }
        }

        public class TheAddFollowerMethod
        {
            [Fact]
            public async Task PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                await client.AddFollower(123, 1234);

                Received.InOrder(async () =>
                {
                    await connection.Post<ProductFollower>(Arg.Is<Uri>(u => u.ToString() == "products/123/followers"),
                                                           Arg.Is<object>(o => o.ToString() == new { user_id = 1234 }.ToString()));
                });
            }
        }

        public class TheDeleteFollowerMethod
        {
            [Fact]
            public async Task DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                await client.DeleteFollower(123, 1234);

                Received.InOrder(async () =>
                {
                    await connection.Delete(Arg.Is<Uri>(u => u.ToString() == "products/123/followers/1234"));
                });
            }
        }
    }
}
