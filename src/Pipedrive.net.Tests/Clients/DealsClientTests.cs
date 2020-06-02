using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Pipedrive.CustomFields;
using Pipedrive.Models.Request;
using Pipedrive.Models.Response;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class DealsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new DealsClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                    Status = DealStatus.lost,
                };

                await client.GetAll(filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Deal>(
                        Arg.Is<Uri>(u => u.ToString() == "deals"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                                && d["owned_by_you"] == "0"
                                && d["status"] == "lost"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
            }
        }

        public class TheGetAllForCurrentMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAllForCurrent(null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                    Status = DealStatus.lost,
                };

                await client.GetAllForCurrent(filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Deal>(
                        Arg.Is<Uri>(u => u.ToString() == "deals"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                                && d["owned_by_you"] == "1"
                                && d["status"] == "lost"),
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
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAllForUserId(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                    Status = DealStatus.lost,
                };

                await client.GetAllForUserId(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Deal>(
                        Arg.Is<Uri>(u => u.ToString() == "deals"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                                && d["user_id"] == "123"
                                && d["status"] == "lost"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
            }
        }

        public class TheGetByNameMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                await client.GetByName("name");

                Received.InOrder(async () =>
                {
                    await connection.GetAll<SimpleDeal>(Arg.Is<Uri>(u => u.ToString() == "deals/find"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                            && d["term"] == "name"));
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<Deal>(Arg.Is<Uri>(u => u.ToString() == "deals/123"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var newDeal = new NewDeal("title");
                var customFields = new Dictionary<string, ICustomField>() { { "5913c8efdcf5c641a516d1fbd498235544b1b195", new LongCustomField(123) } };
                newDeal.CustomFields = customFields;
                client.Create(newDeal);

                connection.Received().Post<Deal>(Arg.Is<Uri>(u => u.ToString() == "deals"),
                    Arg.Is<NewDeal>(d => d.Title == "title" && d.CustomFields == customFields));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var customFields = new Dictionary<string, ICustomField>() { { "5913c8efdcf5c641a516d1fbd498235544b1b195", new LongCustomField(123) } };
                var editDeal = new DealUpdate { Title = "title", CustomFields = customFields };
                client.Edit(123, editDeal);

                connection.Received().Put<Deal>(Arg.Is<Uri>(u => u.ToString() == "deals/123"),
                    Arg.Is<DealUpdate>(d => d.Title == "title" && d.CustomFields == customFields));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "deals/123"));
            }
        }

        public class TheGetUpdatesMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetUpdates(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealUpdateFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetUpdates(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<DealUpdateFlow>(
                        Arg.Is<Uri>(u => u.ToString() == "deals/123/flow"),
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
                var client = new DealsClient(connection);

                await client.GetFollowers(123);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<DealFollower>(
                        Arg.Is<Uri>(u => u.ToString() == "deals/123/followers"),
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
                var client = new DealsClient(connection);

                client.AddFollower(1, 2);

                connection.Received().Post<DealFollower>(Arg.Is<Uri>(u => u.ToString() == "deals/1/followers"),
                    Arg.Is<object>(o => o.ToString() == new { user_id = 2 }.ToString()));
            }
        }

        public class TheDeleteFollowerMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                client.DeleteFollower(1, 461);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "deals/1/followers/461"));
            }
        }

        public class TheGetActivitiesMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetActivities(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealActivityFilters
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
                        Arg.Is<Uri>(u => u.ToString() == "deals/123/activities"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                            && d["id"] == "123"
                            && d["done"] == "1"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
            }
        }

        public class TheGetParticipantsMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetParticipants(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealParticipantFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetParticipants(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<DealParticipant>(
                        Arg.Is<Uri>(u => u.ToString() == "deals/123/participants"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                            && d["id"] == "123"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
            }
        }

        public class TheAddParticipantMethod
        {
            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                client.AddParticipant(1, 2);

                // TODO: check the parameter
                connection.Received().Post<DealParticipant>(Arg.Is<Uri>(u => u.ToString() == "deals/1/participants"),
                    Arg.Any<object>());
            }
        }

        public class TheDeleteParticipantMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                client.DeleteParticipant(123, 456);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "deals/123/participants/456"));
            }
        }

        public class TheGetProductsForDealMethod
        {
            [Fact]
            public void GetProductsForDeal()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var dealProductFilters = new DealProductFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                    IncludeProductData = "1"
                };

                client.GetProductsForDeal(1, dealProductFilters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<DealProduct>(
                        Arg.Is<Uri>(u => u.ToString() == "deals/1/products"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                                                                && d["include_product_data"] == "1"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                                && o.PageCount == 1
                                                && o.StartPage == 0));
                });
            }
        }

        public class TheAddProductToDealMethod
        {
            [Fact]
            public void AddProductToDeal()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var newDealProduct = new NewDealProduct(2, 10, 44);
                client.AddProductToDeal(1, newDealProduct);

                connection.Received().Post<CreatedDealProduct>(Arg.Is<Uri>(u => u.ToString() == "deals/1/products"),
                    Arg.Is(newDealProduct));
            }
        }

        public class TheUpdateDealProductMethod
        {
            [Fact]
            public void UpdateDealProduct()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var dealProductUpdate = new DealProductUpdate();
                client.UpdateDealProduct(1, 2, dealProductUpdate);

                connection.Received().Put<UpdatedDealProduct>(Arg.Is<Uri>(u => u.ToString() == "deals/1/products/2"),
                    Arg.Is(dealProductUpdate));
            }
        }

        public class TheDeleteDealProductMethod
        {
            [Fact]
            public void DeleteDealProduct()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                client.DeleteDealProduct(1, 22);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "deals/1/products/22"));
            }
        }
    }
}
