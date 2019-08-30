using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Pipedrive.Clients;
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
                                                && o.StartPage == 0)
                    );
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
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ProductsClient(connection);

                const string searchTerm = "prod";
                await client.GetByName(searchTerm, null);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Product>(Arg.Is<Uri>(u => u.ToString() == "products/find"),
                                                     Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                                                                                             && d["term"] == searchTerm));
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

                const long productId = 123;
                await client.Get(productId);

                Received.InOrder(async () =>
                {
                    await connection.Get<Product>(Arg.Is<Uri>(u => u.ToString() == $"products/{productId}"));
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

                const long productId = 123;
                await client.GetDealsForProduct(productId);

                Received.InOrder(async () =>
                {
                    await connection.Get<IReadOnlyList<Deal>>(Arg.Is<Uri>(u => u.ToString() == $"products/{productId}/deals"));
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

                const long productId = 123;
                await client.GetFilesForProduct(productId);

                Received.InOrder(async () =>
                {
                    await connection.Get<IReadOnlyList<File>>(Arg.Is<Uri>(u => u.ToString() == $"products/{productId}/files"));
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

                const long productId = 123;
                await client.GetFollowersForProduct(productId);

                Received.InOrder(async () =>
                {
                    await connection.Get<IReadOnlyList<ProductFollower>>(Arg.Is<Uri>(u => u.ToString() == $"products/{productId}/followers"));
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

                const long productId = 123;
                await client.GetPermittedUsers(productId);

                Received.InOrder(async () =>
                {
                    await connection.Get<IReadOnlyList<long>>(Arg.Is<Uri>(u => u.ToString() == $"products/{productId}/permittedUsers"));
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

                const string newProductName = "name";
                await client.Create(new NewProduct(newProductName));

                Received.InOrder(async () =>
                {
                    await connection.Post<Product>(Arg.Is<Uri>(u => u.ToString() == "products"),
                                                   Arg.Is<NewProduct>(d => d.Name == newProductName));
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

                const long productId = 123;
                const long userId = 1234;
                await client.AddFollower(productId, userId);

                Received.InOrder(async () =>
                {
                    await connection.Post<ProductFollower>(Arg.Is<Uri>(u => u.ToString() == $"products/{productId}/followers"),
                                                           Arg.Is<object>(o => o.ToString() == new { user_id = userId }.ToString()));
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

                const long productId = 123;
                const string newProductName = "new product name";
                await client.Edit(productId, new ProductUpdate { Name = newProductName });

                Received.InOrder(async () =>
                {
                    await connection.Put<Product>(Arg.Is<Uri>(u => u.ToString() == $"products/{productId}"),
                                                  Arg.Is<ProductUpdate>(d => d.Name == newProductName));
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

                const long productId = 123;
                await client.Delete(productId);

                Received.InOrder(async () =>
                {
                    await connection.Delete(Arg.Is<Uri>(u => u.ToString() == $"products/{productId}"));
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

                const long productId = 123;
                const long followerId = 1234;
                await client.DeleteFollower(productId, followerId);

                Received.InOrder(async () =>
                {
                    await connection.Delete(Arg.Is<Uri>(u => u.ToString() == $"products/{productId}/followers/{followerId}"));
                });
            }
        }

    }
}
