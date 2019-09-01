using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class RecentsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task ReturnsOnlyDeals()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Deal;

                var newDeal_1 = new NewDeal("Recents Deal Test 1 - Invalid");
                var newDeal_2 = new NewDeal("Recents Deal Test 2 - Valid");
                var newDeal_3 = new NewDeal("Recents Deal Test 3 - Valid");
                var newActivity_4 = new NewActivity("Recents Activity Test 3 - Invalid", "meeting");

                var deal_1 = await fixture.Create(newDeal_1);

                Thread.Sleep(2000);

                var deal_2 = await fixture.Create(newDeal_2);
                var deal_3 = await fixture.Create(newDeal_3);
                var activity_4 = await pipedrive.Activity.Create(newActivity_4);

                Assert.NotNull(deal_1);
                Assert.NotNull(deal_2);
                Assert.NotNull(deal_3);
                Assert.NotNull(activity_4);

                var retrieved = await pipedrive.Recents.GetAll( new RecentsFilters { SinceWhen = deal_2.AddTime.AddSeconds(-1), ItemType = RecentType.deal });
                
                // Cleanup
                await fixture.Delete(deal_1.Id);
                await fixture.Delete(deal_2.Id);
                await fixture.Delete(deal_3.Id);
                await pipedrive.Activity.Delete(activity_4.Id);

                Assert.NotNull(retrieved);
                Assert.Equal(2, retrieved.Count);
            }

            [IntegrationTest]
            public async Task ReturnsOnlyActivities()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Activity;

                var newActivity_1 = new NewActivity("Recents Activity Test 1 - Invalid", "meeting");
                var newActivity_2 = new NewActivity("Recents Activity Test 2 - Valid", "meeting");
                var newActivity_3 = new NewActivity("Recents Activity Test 3 - Valid", "meeting");
                var newDeal_4 = new NewDeal("Recents Deal Test 3 - Invalid");

                var activity_1 = await fixture.Create(newActivity_1);

                Thread.Sleep(2000);

                var activity_2 = await fixture.Create(newActivity_2);
                var activity_3 = await fixture.Create(newActivity_3);
                var deal_4 = await pipedrive.Deal.Create(newDeal_4);

                Assert.NotNull(activity_1);
                Assert.NotNull(activity_2);
                Assert.NotNull(activity_3);
                Assert.NotNull(deal_4);

                var retrieved = await pipedrive.Recents.GetAll(new RecentsFilters { SinceWhen = activity_2.AddTime.AddSeconds(-1), ItemType = RecentType.activity });

                // Cleanup
                await fixture.Delete(activity_1.Id);
                await fixture.Delete(activity_2.Id);
                await fixture.Delete(activity_3.Id);
                await pipedrive.Deal.Delete(deal_4.Id);

                Assert.NotNull(retrieved);
                Assert.Equal(2, retrieved.Count);
            }

            [IntegrationTest]
            public async Task ReturnsAnything()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var newActivity_1 = new NewActivity("Recents Activity Test 1", "meeting");
                var newDeal_2 = new NewDeal("Recents Deal Test 2");

                var activity_1 = await pipedrive.Activity.Create(newActivity_1);
                var deal_2 = await pipedrive.Deal.Create(newDeal_2);

                Assert.NotNull(activity_1);
                Assert.NotNull(deal_2);

                var retrieved = await pipedrive.Recents.GetAll(new RecentsFilters { SinceWhen = activity_1.AddTime.AddSeconds(-1) });

                // Cleanup
                await pipedrive.Activity.Delete(activity_1.Id);
                await pipedrive.Deal.Delete(deal_2.Id);

                Assert.NotNull(retrieved);
                Assert.Equal(2, retrieved.Count);
            }
        }
    }
}
