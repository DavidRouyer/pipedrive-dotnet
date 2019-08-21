using Pipedrive.CustomFields;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class RecentsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task ReturnsDeals()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                var newDeal_1 = new NewDeal("Recents Deal Test 1");
                var newDeal_2 = new NewDeal("Recents Deal Test 2");

                var deal_1 = await fixture.Create(newDeal_1);
                var deal_2 = await fixture.Create(newDeal_2);
                Assert.NotNull(deal_1);
                Assert.NotNull(deal_2);

                var sinceWhen = deal_1.AddTime < deal_2.AddTime ? deal_1.AddTime.AddSeconds(-2) : deal_2.AddTime.AddSeconds(-2);

                var retrieved = await pipedrive.Recents.GetAll( new RecentsFilters { SinceWhen= sinceWhen, ItemType=RecentType.deal });
                
                // Cleanup
                await fixture.Delete(deal_1.Id);
                await fixture.Delete(deal_2.Id);

                Assert.NotNull(retrieved);
                Assert.Equal(2, retrieved.Count);


            }
            [IntegrationTest]
            public async Task ReturnsActivities()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Activity;

                var newA_1 = new NewActivity("Recents Activity Test 1", "meeting");
                var newA_2 = new NewActivity("Recents Activity Test 2", "meeting");

                var item_1 = await fixture.Create(newA_1);
                var item_2 = await fixture.Create(newA_2);
                Assert.NotNull(item_1);
                Assert.NotNull(item_2);

                var sinceWhen = item_1.AddTime < item_2.AddTime ? item_1.AddTime.AddSeconds(-2) : item_2.AddTime.AddSeconds(-2);

                var retrieved = await pipedrive.Recents.GetAll(new RecentsFilters { SinceWhen = sinceWhen, ItemType = RecentType.activity });

                // Cleanup
                await fixture.Delete(item_1.Id);
                await fixture.Delete(item_2.Id);

                Assert.NotNull(retrieved);
                Assert.Equal(2, retrieved.Count);
            }
            [IntegrationTest]
            public async Task ReturnsAnything()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var newA_1 = new NewActivity("Recents Activity Both Test 1", "meeting");
                var newA_2 = new NewDeal("Recents Deal Both Test 2");

                var item_1 = await pipedrive.Activity.Create(newA_1);
                var item_2 = await pipedrive.Deal.Create(newA_2);
                Assert.NotNull(item_1);
                Assert.NotNull(item_2);

                var sinceWhen = item_1.AddTime < item_2.AddTime ? item_1.AddTime.AddSeconds(-2) : item_2.AddTime.AddSeconds(-2);

                var retrieved = await pipedrive.Recents.GetAll(new RecentsFilters { SinceWhen = sinceWhen });

                // Cleanup
                await pipedrive.Activity.Delete(item_1.Id);
                await pipedrive.Deal.Delete(item_2.Id);

                Assert.NotNull(retrieved);
                Assert.Equal(2, retrieved.Count);
            }
        }
    }
}
