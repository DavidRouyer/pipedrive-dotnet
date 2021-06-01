using System;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class SubscriptionsClientTests
    {
        public class TheGetAllByDealIdMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveSubscriptions()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var subscriptions = await pipedrive.Subscription.GetAllForDealId(540);

                Assert.True(subscriptions.Count == 1);
                Assert.True(subscriptions[0].Infinite);
                Assert.True(subscriptions[0].IsActive);
            }
        }

        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveStages()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var subscription = await pipedrive.Subscription.Get(1);

                Assert.True(subscription.IsActive);
            }
        }

        public class TheCreateRecurringMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Subscription;

                var newRecurringSubscription = new NewRecurringSubscription()
                {
                    DealId = 1,
                    Currency = "EUR",
                    CadenceType = "monthly",
                    CycleAmount = 100,
                    StartDate = DateTime.UtcNow.AddDays(3).Date,
                };

                var deal = await fixture.CreateRecurring(newRecurringSubscription);
                Assert.NotNull(deal);

                var retrieved = await fixture.Get(deal.Id);
                Assert.NotNull(retrieved);
                Assert.Equal(DateTime.UtcNow.AddDays(3).Date, newRecurringSubscription.StartDate.Date);

                // Cleanup
                await fixture.Delete(deal.Id);
            }
        }

        public class TheCreateInstallmentMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Subscription;

                var newInstallmentSubscription = new NewInstallmentSubscription()
                {
                    DealId = 1,
                    Currency = "EUR",
                };

                var deal = await fixture.CreateInstallment(newInstallmentSubscription);
                Assert.NotNull(deal);

                var retrieved = await fixture.Get(deal.Id);
                Assert.NotNull(retrieved);
                Assert.Equal(1, newInstallmentSubscription.DealId);

                // Cleanup
                await fixture.Delete(deal.Id);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Subscription;

                var newDeal = new NewInstallmentSubscription() { DealId = 1 };
                var deal = await fixture.CreateInstallment(newDeal);

                var createdSubscription = await fixture.Get(deal.Id);

                Assert.NotNull(createdSubscription);

                await fixture.Delete(createdSubscription.Id);

                var deletedSubscription = await fixture.Get(createdSubscription.Id);

                Assert.False(deletedSubscription.IsActive);
            }
        }
    }
}
