using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class SubscriptionsClientTests
    {
        public class TheGetByDealIdMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveSubscription()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var subscription = await pipedrive.Subscription.GetByDealId(540);

                Assert.False(subscription.Infinite);
                Assert.True(subscription.IsActive);
            }
        }

        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveSubscription()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var subscription = await pipedrive.Subscription.Get(1);

                Assert.True(subscription.IsActive);
            }
        }

        public class TheGetPaymentsMethod
        {
            [IntegrationTest]
            public async Task CanRetrievePayments()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var payments = await pipedrive.Subscription.GetPayments(1);

                Assert.Equal(3, payments.Count);
            }
        }

        public class TheCreateRecurringMethod
        {
            [IntegrationTest]
            public async Task CanCreateWithoutPayment()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Subscription;

                var newRecurringSubscription = new NewRecurringSubscription()
                {
                    DealId = 1,
                    Description = "a subscription",
                    Currency = "EUR",
                    CadenceType = "monthly",
                    CycleAmount = 200,
                    Infinite = true,
                    StartDate = DateTime.UtcNow.AddDays(3).Date,
                };

                var subscription = await fixture.CreateRecurring(newRecurringSubscription);
                Assert.NotNull(subscription);

                var retrieved = await fixture.Get(subscription.Id);
                Assert.NotNull(retrieved);
                Assert.True(newRecurringSubscription.Infinite);
                Assert.Equal(DateTime.UtcNow.AddDays(3).Date, subscription.StartDate);

                // Cleanup
                await fixture.Delete(subscription.Id);
            }

            [IntegrationTest]
            public async Task CanCreateInfinite()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Subscription;

                var newRecurringSubscription = new NewRecurringSubscription()
                {
                    DealId = 1,
                    Description = "a subscription",
                    Currency = "EUR",
                    CadenceType = "monthly",
                    CycleAmount = 200,
                    Infinite = true,
                    StartDate = DateTime.UtcNow.AddDays(3).Date,
                    Payments = new List<NewPayment>()
                    {
                        new NewPayment() { Amount = 200, Description = "my payment", DueAt = DateTime.Now }
                    }
                };

                var subscription = await fixture.CreateRecurring(newRecurringSubscription);
                Assert.NotNull(subscription);

                var retrieved = await fixture.Get(subscription.Id);
                Assert.NotNull(retrieved);
                Assert.True(newRecurringSubscription.Infinite);
                Assert.Equal(DateTime.UtcNow.AddDays(3).Date, subscription.StartDate);

                // Cleanup
                await fixture.Delete(subscription.Id);
            }

            [IntegrationTest]
            public async Task CanCreateLimited()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Subscription;

                var newRecurringSubscription = new NewRecurringSubscription()
                {
                    DealId = 1,
                    Description = "a subscription",
                    Currency = "EUR",
                    CadenceType = "monthly",
                    CycleAmount = 200,
                    CyclesCount = 12,
                    StartDate = DateTime.UtcNow.AddDays(3).Date,
                    Payments = new List<NewPayment>()
                    {
                        new NewPayment() { Amount = 400, Description = "my payment", DueAt = DateTime.Now }
                    }
                };

                var subscription = await fixture.CreateRecurring(newRecurringSubscription);
                Assert.NotNull(subscription);

                var retrieved = await fixture.Get(subscription.Id);
                Assert.NotNull(retrieved);
                Assert.False(subscription.Infinite);
                Assert.Equal(12, subscription.CyclesCount);
                Assert.Equal(DateTime.UtcNow.AddDays(3).Date, subscription.StartDate);

                // Cleanup
                await fixture.Delete(subscription.Id);
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
                    Payments = new List<NewPayment>()
                    {
                        new NewPayment() { Amount = 200, Description = "my payment", DueAt = DateTime.Now }
                    }
                };

                var subscription = await fixture.CreateInstallment(newInstallmentSubscription);
                Assert.NotNull(subscription);

                var retrieved = await fixture.Get(subscription.Id);
                Assert.NotNull(retrieved);
                Assert.Equal(1, newInstallmentSubscription.DealId);

                // Cleanup
                await fixture.Delete(subscription.Id);
            }
        }

        public class TheCancelRecurringMethod
        {
            [IntegrationTest]
            public async Task CanCancel()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Subscription;

                var newSubscription = new NewRecurringSubscription()
                {
                    DealId = 1,
                    Description = "a subscription",
                    Currency = "EUR",
                    CadenceType = "monthly",
                    CycleAmount = 200,
                    Infinite = true,
                    StartDate = DateTime.UtcNow.AddDays(3).Date,
                    Payments = new List<NewPayment>()
                    {
                        new NewPayment() { Amount = 200, Description = "my payment", DueAt = DateTime.Now }
                    }
                };

                var subscription = await fixture.CreateRecurring(newSubscription);

                var createdSubscription = await fixture.Get(subscription.Id);

                Assert.NotNull(createdSubscription);

                await fixture.CancelRecurring(createdSubscription.Id, new CancelRecurringSubscription() { EndDate = DateTime.UtcNow.AddDays(6).Date });

                var cancelledSubscription = await fixture.Get(createdSubscription.Id);

                Assert.Equal("canceled", cancelledSubscription.FinalStatus);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Subscription;

                var newSubscription = new NewInstallmentSubscription()
                {
                    DealId = 1,
                    Currency = "EUR",
                    Payments = new List<NewPayment>()
                    {
                        new NewPayment() { Amount = 200, Description = "my payment", DueAt = DateTime.Now }
                    }
                };
                var subscription = await fixture.CreateInstallment(newSubscription);

                var createdSubscription = await fixture.Get(subscription.Id);

                Assert.NotNull(createdSubscription);

                await fixture.Delete(createdSubscription.Id);

                var deletedSubscription = await fixture.Get(createdSubscription.Id);

                Assert.False(deletedSubscription.IsActive);
            }
        }
    }
}
