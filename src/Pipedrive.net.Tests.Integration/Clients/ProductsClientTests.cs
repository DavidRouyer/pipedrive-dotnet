using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class ProductsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new ProductFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var products = await pipedrive.Product.GetAll(options);
                Assert.Equal(3, products.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new ProductFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var products = await pipedrive.Product.GetAll(options);
                Assert.Equal(2, products.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new ProductFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Product.GetAll(startOptions);

                var skipStartOptions = new ProductFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Product.GetAll(skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheSearchMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveProducts()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var products = await pipedrive.Product.Search("productname", ProductSearchFilters.None);

                Assert.True(products.Count == 1);
            }
        }

        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveProduct()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var product = await pipedrive.Product.Get(2);

                Assert.Equal("productname", product.Name);
            }
        }

        public class TheGetDealsForProductMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveDeals()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var deals = await pipedrive.Product.GetDealsForProduct(2);

                Assert.Equal(1, deals.Count);
            }
        }

        public class TheGetFilesForProductMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCount()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var files = await pipedrive.Product.GetFilesForProduct(1);

                Assert.Equal(1, files.Count);
            }
        }

        public class TheGetFollowersForProductMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCount()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var followers = await pipedrive.Product.GetFollowersForProduct(1);

                Assert.Equal(1, followers.Count);
            }
        }

        public class TheGetPermittedUsersMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCount()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var permittedUsers = await pipedrive.Product.GetPermittedUsers(2);

                Assert.Equal(2, permittedUsers.Count);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Product;

                var newProduct = new NewProduct("New Product Name")
                {
                    Prices = new List<NewProductPrice> { new NewProductPrice { Currency = "GBP", Price = 10.23M } }
                };

                var product = await fixture.Create(newProduct);
                Assert.NotNull(product);

                var retrieved = await fixture.Get(product.Id);
                Assert.NotNull(retrieved);
                Assert.Equal("GBP", retrieved.Prices.First().Currency);
                Assert.Equal(10.23M, retrieved.Prices.First().Price);

                // Cleanup
                await fixture.Delete(product.Id);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Product;

                var newProduct = new NewProduct("product")
                {
                    Prices = new List<NewProductPrice> { new NewProductPrice { Currency = "GBP", Price = 10.23M } }
                };
                var product = await fixture.Create(newProduct);

                var editedProduct = product.ToUpdate();
                editedProduct.Name = "updated-name";
                editedProduct.Prices.First(x => x.Currency == "GBP").Price = 20.50M;

                var updatedProduct = await fixture.Edit(product.Id, editedProduct);

                Assert.Equal("updated-name", updatedProduct.Name);
                Assert.Equal(20.50M, updatedProduct.Prices["GBP"].Price);

                // Cleanup
                await fixture.Delete(updatedProduct.Id);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Product;

                var newProduct = new NewProduct("new-name");
                var product = await fixture.Create(newProduct);

                var createdProduct = await fixture.Get(product.Id);

                Assert.NotNull(createdProduct);

                await fixture.Delete(createdProduct.Id);

                var deletedProduct = await fixture.Get(createdProduct.Id);
                Assert.False(deletedProduct.ActiveFlag);
            }
        }

        public class TheAddFollowerMethod
        {
            [IntegrationTest]
            public async Task CanAddFollower()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Product;

                var addFollower = await fixture.AddFollower(1, 9953182);
                Assert.NotNull(addFollower);
            }
        }

        public class TheDeleteFollowerMethod
        {
            [IntegrationTest]
            public async Task CanDeleteFollower()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Product;

                await fixture.DeleteFollower(1, 1);
            }
        }
    }
}
