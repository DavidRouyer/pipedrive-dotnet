using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Pipedrive.Models.Common.Webhooks;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class WebhookClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new WebhooksClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new WebhooksClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Webhook>(Arg.Is<Uri>(u => u.ToString() == "webhooks"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new WebhooksClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new WebhooksClient(connection);

                var newWebhook = new NewWebhook("https://test.com", EventAction.All, EventObject.All);
                client.Create(newWebhook);

                connection.Received().Post<Webhook>(Arg.Is<Uri>(u => u.ToString() == "webhooks"),
                    Arg.Is<NewWebhook>(df => df.EventAction.ToString() == "*"
                        && df.EventObject.ToString() == "*"
                        && df.SubscriptionUrl == "https://test.com"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new WebhooksClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "webhooks/123"));
            }
        }
    }
}
