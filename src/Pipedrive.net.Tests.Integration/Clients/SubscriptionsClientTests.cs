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

                Assert.NotNull(subscription);
                Assert.True(subscription.Infinite);
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

                Assert.NotNull(subscription);
                Assert.True(subscription.Infinite);
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

                Assert.NotNull(subscription);
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
                Assert.Equal(1, subscription.DealId);

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

        public class TheEditRecurringMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Subscription;

                var subscription = await fixture.CreateRecurring(new NewRecurringSubscription()
                {
                    DealId = 1,
                    Description = "a subscription",
                    Currency = "EUR",
                    CadenceType = "monthly",
                    CycleAmount = 200,
                    Infinite = true,
                    StartDate = DateTime.UtcNow.AddDays(3).Date,
                });

                var subscriptionToUpdate = subscription.ToRecurringUpdate();
                subscriptionToUpdate.CycleAmount = 400;
                subscriptionToUpdate.EffectiveDate = DateTime.UtcNow.AddDays(4).Date;

                var updatedSubscription = await fixture.EditRecurring(subscription.Id, subscriptionToUpdate);

                Assert.NotNull(updatedSubscription);
                Assert.True(updatedSubscription.Infinite);
                Assert.Equal(DateTime.UtcNow.AddDays(3).Date, updatedSubscription.StartDate);
                Assert.Equal(400, updatedSubscription.CycleAmount);

                // Cleanup
                await fixture.Delete(updatedSubscription.Id);
            }
        }

        public class TheEditInstallmentMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Subscription;

                var subscription = await fixture.CreateInstallment(new NewInstallmentSubscription()
                {
                    DealId = 1,
                    Currency = "EUR",
                    Payments = new List<NewPayment>()
                    {
                        new NewPayment() { Amount = 200, Description = "my payment", DueAt = DateTime.Now }
                    }
                });

                var subscriptionToUpdate = subscription.ToInstallmentUpdate();
                subscriptionToUpdate.Payments = new List<NewPayment>()
                {
                    new NewPayment() { Amount = 400, Description = "my payment 2", DueAt = DateTime.Now }
                };

                var updatedSubscription = await fixture.EditInstallment(subscription.Id, subscriptionToUpdate);
                var updatedSubscriptionPayments = await fixture.GetPayments(updatedSubscription.Id);

                Assert.NotNull(updatedSubscription);
                Assert.Equal(1, updatedSubscription.DealId);
                Assert.Equal(400, updatedSubscriptionPayments[0].Amount);
                Assert.Equal("my payment 2", updatedSubscriptionPayments[0].Description);

                // Cleanup
                await fixture.Delete(subscription.Id);
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
