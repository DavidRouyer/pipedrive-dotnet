using System;
using System.Linq;
using System.Threading.Tasks;
using Pipedrive.CustomFields;
using Pipedrive.Models.Request;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class DealsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new DealFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var deals = await pipedrive.Deal.GetAll(options);
                Assert.Equal(3, deals.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new DealFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var deals = await pipedrive.Deal.GetAll(options);
                Assert.Equal(2, deals.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new DealFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Deal.GetAll(startOptions);

                var skipStartOptions = new DealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Deal.GetAll(skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheGetByNameMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveDeals()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var deals = await pipedrive.Deal.GetByName("mon deal");

                Assert.Equal(1, deals.Count);
            }
        }

        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveDeal()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var deal = await pipedrive.Deal.Get(135);

                Assert.True(deal.Active);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                var newDeal = new NewDeal("title");
                newDeal.CustomFields["8bbb7cf46a85a3a42538d500a29ecc8ac244eacd"] = new StringCustomField("my custom string field");

                var deal = await fixture.Create(newDeal);
                Assert.Equal("my custom string field", ((StringCustomField)deal.CustomFields["8bbb7cf46a85a3a42538d500a29ecc8ac244eacd"]).Value);
                Assert.NotNull(deal);

                var retrieved = await fixture.Get(deal.Id);
                Assert.NotNull(retrieved);
                Assert.Equal("my custom string field", ((StringCustomField)retrieved.CustomFields["8bbb7cf46a85a3a42538d500a29ecc8ac244eacd"]).Value);

                // Cleanup
                await fixture.Delete(deal.Id);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                var newDeal = new NewDeal("new-title");
                var deal = await fixture.Create(newDeal);

                var editDeal = deal.ToUpdate();
                editDeal.Title = "updated-title";
                editDeal.Status = DealStatus.lost;
                editDeal.CustomFields["33f60aa418da91210968773dda914742dd69d9c8"] = new StringCustomField("my string");
                editDeal.CustomFields["429ced4a0dcd16b9be5048453c1ff6748a8c4646"] = new StringCustomField("my autocomplete string");
                editDeal.CustomFields["8bbb7cf46a85a3a42538d500a29ecc8ac244eacd"] = new StringCustomField("my large text string");
                editDeal.CustomFields["110dee8ec4d2f63bb4a739ceb537d59bdec70841"] = new LongCustomField(123);
                editDeal.CustomFields["aeb53a8dfadae3725183f9ef1deeeaf416c43b3b"] = new MonetaryCustomField(123.45m, "EUR");
                editDeal.CustomFields["29ea3aec79d40dc23717c8dc2ae733b80d4d106d"] = new DateCustomField(new DateTime(2018, 12, 31));
                editDeal.CustomFields["fafd71954fc387aad08186ab7aead0697fba4229"] = new DateRangeCustomField(new DateTime(2018, 12, 30), new DateTime(2018, 12, 31));
                editDeal.CustomFields["bde564bd45f0381b54eea85d5c70a904d17458d9"] = new TimeCustomField(new TimeSpan(23, 59, 59), 0);
                editDeal.CustomFields["9ef10a2bcd8d149ddd0a64988762dc5a080a9230"] = new TimeRangeCustomField(new TimeSpan(23, 59, 58), new TimeSpan(23, 59, 59), 0);
                editDeal.CustomFields["2008db4fe093862089023b01ad80feabac24d7d0"] = new AddressCustomField("value", "subpremise", "streetNumber", "route", "sublocality", "locality", "adminAreaLevel1", "adminAreaLevel2", "country", "postalCode", "formattedAddress");
                editDeal.CustomFields["8a1cf3eacd582191a48730b5d953daa877c0ebe7"] = new StringCustomField("0606060606"); // Phone
                editDeal.CustomFields["796428c82dfc3595032a4330238aa06d354db5da"] = new StringCustomField("4"); // Single option
                editDeal.CustomFields["d6f06c499d7692a76f9239545817b441273a00eb"] = new StringCustomField("2,3"); // Multiple options
                editDeal.CustomFields["91f2a72b3373f7a382b1313c047ebd67ed117721"] = new OrganizationCustomField() { Value = 5 };
                editDeal.CustomFields["b7f70559583cdfd159d4831697d0540c297ef26f"] = new PersonCustomField() { Value = 6 };
                editDeal.CustomFields["a0d868dde5bb67a59117d807fae1d6b3b025731e"] = new UserCustomField() { Value = 2616956 };

                var updatedDeal = await fixture.Edit(deal.Id, editDeal);

                Assert.Equal("updated-title", updatedDeal.Title);
                Assert.Equal(DealStatus.lost, updatedDeal.Status);
                Assert.Equal("my string", ((StringCustomField)updatedDeal.CustomFields["33f60aa418da91210968773dda914742dd69d9c8"]).Value);
                Assert.Equal("my autocomplete string", ((StringCustomField)updatedDeal.CustomFields["429ced4a0dcd16b9be5048453c1ff6748a8c4646"]).Value);
                Assert.Equal("my large text string", ((StringCustomField)updatedDeal.CustomFields["8bbb7cf46a85a3a42538d500a29ecc8ac244eacd"]).Value);
                Assert.Equal(123, ((LongCustomField)updatedDeal.CustomFields["110dee8ec4d2f63bb4a739ceb537d59bdec70841"]).Value);
                Assert.Equal(123.45m, ((MonetaryCustomField)updatedDeal.CustomFields["aeb53a8dfadae3725183f9ef1deeeaf416c43b3b"]).Value);
                Assert.Equal("EUR", ((MonetaryCustomField)updatedDeal.CustomFields["aeb53a8dfadae3725183f9ef1deeeaf416c43b3b"]).Currency);
                Assert.Equal(new DateTime(2018, 12, 31), ((DateCustomField)updatedDeal.CustomFields["29ea3aec79d40dc23717c8dc2ae733b80d4d106d"]).Value);
                Assert.Equal(new DateTime(2018, 12, 30), ((DateRangeCustomField)updatedDeal.CustomFields["fafd71954fc387aad08186ab7aead0697fba4229"]).StartDate);
                Assert.Equal(new DateTime(2018, 12, 31), ((DateRangeCustomField)updatedDeal.CustomFields["fafd71954fc387aad08186ab7aead0697fba4229"]).EndDate);
                Assert.Equal(new TimeSpan(23, 59, 59), ((TimeCustomField)updatedDeal.CustomFields["bde564bd45f0381b54eea85d5c70a904d17458d9"]).Value);
                Assert.Equal(0, ((TimeCustomField)updatedDeal.CustomFields["bde564bd45f0381b54eea85d5c70a904d17458d9"]).TimezoneId);
                Assert.Equal(new TimeSpan(23, 59, 58), ((TimeRangeCustomField)updatedDeal.CustomFields["9ef10a2bcd8d149ddd0a64988762dc5a080a9230"]).StartTime);
                Assert.Equal(new TimeSpan(23, 59, 59), ((TimeRangeCustomField)updatedDeal.CustomFields["9ef10a2bcd8d149ddd0a64988762dc5a080a9230"]).EndTime);
                Assert.Equal(0, ((TimeRangeCustomField)updatedDeal.CustomFields["9ef10a2bcd8d149ddd0a64988762dc5a080a9230"]).TimezoneId);
                Assert.Equal("value", ((AddressCustomField)updatedDeal.CustomFields["2008db4fe093862089023b01ad80feabac24d7d0"]).Value);
                Assert.Equal("0606060606", ((StringCustomField)updatedDeal.CustomFields["8a1cf3eacd582191a48730b5d953daa877c0ebe7"]).Value);
                Assert.Equal("4", ((StringCustomField)updatedDeal.CustomFields["796428c82dfc3595032a4330238aa06d354db5da"]).Value);
                Assert.Equal("2,3", ((StringCustomField)updatedDeal.CustomFields["d6f06c499d7692a76f9239545817b441273a00eb"]).Value);
                Assert.Equal(5, ((OrganizationCustomField)updatedDeal.CustomFields["91f2a72b3373f7a382b1313c047ebd67ed117721"]).Value);
                Assert.Equal(6, ((PersonCustomField)updatedDeal.CustomFields["b7f70559583cdfd159d4831697d0540c297ef26f"]).Value);
                Assert.Equal(2616956, ((UserCustomField)updatedDeal.CustomFields["a0d868dde5bb67a59117d807fae1d6b3b025731e"]).Value);

                // Cleanup
                await fixture.Delete(updatedDeal.Id);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                var newDeal = new NewDeal("new-title");
                var deal = await fixture.Create(newDeal);

                var createdDeal = await fixture.Get(deal.Id);

                Assert.NotNull(createdDeal);

                await fixture.Delete(createdDeal.Id);

                var deletedDeal = await fixture.Get(createdDeal.Id);

                Assert.Equal(DealStatus.deleted, deletedDeal.Status);
            }
        }

        public class TheGetUpdatesMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new DealUpdateFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var dealUpdates = await pipedrive.Deal.GetUpdates(1, options);
                Assert.Equal(3, dealUpdates.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new DealUpdateFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var deals = await pipedrive.Deal.GetUpdates(1, options);
                Assert.Equal(2, deals.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new DealUpdateFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Deal.GetUpdates(1, startOptions);

                var skipStartOptions = new DealUpdateFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Deal.GetUpdates(1, skipStartOptions);

                Assert.NotEqual(firstPage[0].Data.Id, secondPage[0].Data.Id);
            }
        }

        public class TheGetFollowersMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCount()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var followers = await pipedrive.Deal.GetFollowers(1);
                Assert.Equal(1, followers.Count);
            }
        }

        public class TheAddFollowerMethod
        {
            [IntegrationTest]
            public async Task CanAddFollower()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                var addFollower = await fixture.AddFollower(1, 595707);
                Assert.NotNull(addFollower);
            }
        }

        public class TheDeleteFollowerMethod
        {
            [IntegrationTest]
            public async Task CanDeleteFollower()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                await fixture.DeleteFollower(1, 461);
            }
        }

        public class TheGetActivitiesMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new DealUpdateFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var dealUpdates = await pipedrive.Deal.GetUpdates(1, options);
                Assert.Equal(3, dealUpdates.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new DealActivityFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var deals = await pipedrive.Deal.GetActivities(1, options);
                Assert.Equal(2, deals.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new DealActivityFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Deal.GetActivities(1, startOptions);

                var skipStartOptions = new DealActivityFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Deal.GetActivities(1, skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheGetParticipantsMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new DealParticipantFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var dealUpdates = await pipedrive.Deal.GetParticipants(4, options);
                Assert.Equal(3, dealUpdates.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new DealParticipantFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var deals = await pipedrive.Deal.GetParticipants(4, options);
                Assert.Equal(2, deals.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new DealParticipantFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Deal.GetParticipants(4, startOptions);

                var skipStartOptions = new DealParticipantFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Deal.GetParticipants(4, skipStartOptions);

                Assert.NotEqual(firstPage[0].PersonId, secondPage[0].PersonId);
            }
        }

        public class TheAddParticipantMethod
        {
            [IntegrationTest]
            public async Task CanAddParticipant()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                var addParticipant = await fixture.AddParticipant(1, 141);
                Assert.NotNull(addParticipant);
            }
        }

        public class TheDeleteParticipantMethod
        {
            [IntegrationTest]
            public async Task CanDeleteParticipant()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                await fixture.DeleteParticipant(1, 5);
            }
        }

        public class TheGetProductsForDealMethod
        {
            [IntegrationTest]
            public async Task GetProductsForDeal()
            {
                var dealProductFilters = new DealProductFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 0,
                    IncludeProductData = "1"
                };

                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                var dealProducts = await fixture.GetProductsForDeal(1, dealProductFilters);

                Assert.Equal(2, dealProducts.Count);
                Assert.True(dealProducts.All(x => x.DealId == 1));
            }
        }

        public class TheAddProductToDealMethod
        {
            [IntegrationTest]
            public async Task AddProductToDeal()
            {
                var newDealProduct = new NewDealProduct(1, 10, 30)
                {
                    DiscountPercentage = 55,
                    EnabledFlag = true
                };

                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                var dealProduct = await fixture.AddProductToDeal(1, newDealProduct);

                Assert.Equal(1, dealProduct.DealId);
                Assert.Equal(1, dealProduct.ProductId);
                Assert.Equal(10, dealProduct.ItemPrice);
                Assert.Equal(30, dealProduct.Quantity);
                Assert.Equal(135, dealProduct.Sum);
                Assert.Equal(55, dealProduct.DiscountPercentage);

                // Cleanup
                await fixture.DeleteDealProduct(1, dealProduct.ProductAttachmentId.Value);
            }
        }

        public class TheUpdateDealProductMethod
        {
            [IntegrationTest]
            public async Task UpdateDealProduct()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                var createdDealProduct = await fixture.AddProductToDeal(1, new NewDealProduct(1, 10, 30));

                var dealProductUpdate = new DealProductUpdate
                {
                    ItemPrice = 44,
                    Quantity = 1,
                    Duration = 1,
                    DiscountPercentage = 11
                };

                var updatedDealProduct = await fixture.UpdateDealProduct(1, createdDealProduct.ProductAttachmentId.Value, dealProductUpdate);

                Assert.Equal(1, updatedDealProduct.DealId);
                Assert.Equal(1, updatedDealProduct.ProductId);
                Assert.Equal(44, updatedDealProduct.ItemPrice);
                Assert.Equal(1, updatedDealProduct.Quantity);
                Assert.Equal(39.16m, updatedDealProduct.Sum);

                // Cleanup
                await fixture.DeleteDealProduct(1, createdDealProduct.ProductAttachmentId.Value);
            }
        }

        public class TheDeleteDealProductMethod
        {
            [IntegrationTest]
            public async Task DeleteDealProduct()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                var dealProduct = await fixture.AddProductToDeal(1, new NewDealProduct(1, 10, 30));

                await fixture.DeleteDealProduct(1, dealProduct.ProductAttachmentId.Value);
            }
        }
    }
}
