using System;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class SubscriptionsClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new SubscriptionsClient(null));
            }
        }

        public class TheGetForDealIdMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new SubscriptionsClient(connection);

                await client.GetAllForDealId(123);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Subscription>(
                        Arg.Is<Uri>(u => u.ToString() == "subscriptions/find/123"));
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new SubscriptionsClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<Subscription>(Arg.Is<Uri>(u => u.ToString() == "subscriptions/123"));
                });
            }
        }

        public class TheCreateRecurringMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new SubscriptionsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.CreateRecurring(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new SubscriptionsClient(connection);

                var newSubscription = new NewRecurringSubscription() { DealId = 1, Currency = "EUR", CadenceType = "monthly", CycleAmount = 100, StartDate = DateTime.UtcNow };
                client.CreateRecurring(newSubscription);

                connection.Received().Post<Subscription>(Arg.Is<Uri>(u => u.ToString() == "subscriptions/recurring"),
                    Arg.Is<NewRecurringSubscription>(d => d.DealId == 1 && d.Currency == "EUR" && d.CadenceType == "monthly" && d.CycleAmount == 100));
            }
        }

        public class TheCreateInstallmentMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new SubscriptionsClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.CreateInstallment(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new SubscriptionsClient(connection);

                var newSubscription = new NewInstallmentSubscription() { DealId = 1, Currency = "EUR" };
                client.CreateInstallment(newSubscription);

                connection.Received().Post<Subscription>(Arg.Is<Uri>(u => u.ToString() == "subscriptions/installment"),
                    Arg.Is<NewInstallmentSubscription>(d => d.DealId == 1 && d.Currency == "EUR"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new SubscriptionsClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "subscriptions/123"));
            }
        }
    }
}
