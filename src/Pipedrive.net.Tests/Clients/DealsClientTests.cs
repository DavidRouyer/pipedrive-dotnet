using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Pipedrive.CustomFields;
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

        public class TheSearchMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Search(null, null));
            }

            [Fact]
            public async Task EnsuresSearchTermIsMoreThan2Characters()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                var exception = await Assert.ThrowsAsync<ArgumentException>(() => client.Search("p", DealSearchFilters.None));
                Assert.Equal("The search term must have at least 2 characters (Parameter 'term')", exception.Message);
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealSearchFilters
                {
                    ExactMatch = true,
                    Status = DealStatus.lost,
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.Search("name", filters);

                Received.InOrder(async () =>
                {
                    await connection.SearchAll<SearchResult<SimpleDeal>>(Arg.Is<Uri>(u => u.ToString() == "deals/search"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 3
                            && d["term"] == "name"
                            && d["exact_match"] == "True"
                            && d["status"] == "lost"),
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

        public class TheDeleteMultipleMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Delete(null));
            }

            [Fact]
            public async Task EnsuresNonEmptyArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentException>(() => client.Delete(new List<long>()));
            }

            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                client.Delete(new List<long>() { 123, 456 });

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "deals?ids=123,456"));
            }
        }

        public class TheGetSummaryMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetSummary(null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealsSummaryFilters
                {
                    FilterId = 1,
                    Status = DealStatus.open,
                };

                await client.GetSummary(filters);

                Received.InOrder(async () =>
                {
                    await connection.Get<DealSummary>(
                        Arg.Is<Uri>(u => u.ToString() == "deals/summary"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 2
                            && d["filter_id"] == "1"
                            && d["status"] == "open"));
                });
            }
        }

        public class TheGetTimelineMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetTimeline(null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealsTimelineFilters
                {
                    StartDate = new DateTime(2021, 01, 01),
                    Interval = DateInterval.Month,
                    Amount = 1,
                    FieldKey = "close_time"
                };

                await client.GetTimeline(filters);

                Received.InOrder(async () =>
                {
                    await connection.Get<IReadOnlyList<DealTimeline>>(
                        Arg.Is<Uri>(u => u.ToString() == "deals/timeline"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 4
                            && d["start_date"] == "2021-01-01"
                            && d["interval"] == "month"
                            && d["amount"] == "1"
                            && d["field_key"] == "close_time"));
                });
            }
        }

        public class TheGetFilesMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new DealsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetFiles(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new DealsClient(connection);

                var filters = new DealFileFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                    IncludeDeletedFiles = true,
                };

                await client.GetFiles(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<File>(
                        Arg.Is<Uri>(u => u.ToString() == "deals/123/files"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                            && d["include_deleted_files"] == "1"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0));
                });
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
                    await connection.GetAll<EntityUpdateFlow>(
                        Arg.Is<Uri>(u => u.ToString() == "deals/123/flow"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 0),
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

                client.GetProducts(1, dealProductFilters);

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
                client.AddProduct(1, newDealProduct);

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
                client.UpdateProduct(1, 2, dealProductUpdate);

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

                client.DeleteProduct(1, 22);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "deals/1/products/22"));
            }
        }
    }
}
