using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class WebhooksClientTests
    {
        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Webhook;

                var newWebhook = new NewWebhook("http://example.com", Models.Common.Webhooks.EventAction.All, Models.Common.Webhooks.EventObject.All);

                var webhook = await fixture.Create(newWebhook);
                Assert.NotNull(webhook);

                var retrieved = await fixture.GetAll();
                Assert.True(retrieved.Count > 0, "Expected count to be greater than 0.");

                // Cleanup
                await fixture.Delete(webhook.Id);
            }
        }

        public class TheParseWebhookDealResponseMethod
        {
            [Fact]
            public async Task DeserializeCreateInformations()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var stream = Helper.LoadFixture("webhook_deal_create.json");

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var fixture = await reader.ReadToEndAsync();

                    var result = pipedrive.Webhook.ParseWebhookDealResponse(fixture);
                }
            }

            [Fact]
            public async Task DeserializeUpdateInformations()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var stream = Helper.LoadFixture("webhook_deal_update.json");

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var fixture = await reader.ReadToEndAsync();

                    var result = pipedrive.Webhook.ParseWebhookDealResponse(fixture);
                }
            }
        }

        public class TheParseWebhookActivityResponseMethod
        {
            [Fact]
            public async Task DeserializeUpdateInformations()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var stream = Helper.LoadFixture("webhook_activity_update.json");

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var fixture = await reader.ReadToEndAsync();

                    var result = pipedrive.Webhook.ParseWebhookActivityResponse(fixture);
                }
            }
        }

        public class TheParseWebhookOrganizationResponseMethod
        {
            [Fact]
            public async Task DeserializeCreateInformations()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var stream = Helper.LoadFixture("webhook_organization_create.json");

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var fixture = await reader.ReadToEndAsync();

                    var result = pipedrive.Webhook.ParseWebhookOrganizationResponse(fixture);
                }
            }
        }

        public class TheParseWebhookPersonResponseMethod
        {
            [Theory]
            [InlineData("webhook_person_update.json")]
            [InlineData("webhook_person_update_import.json")]
            public async Task DeserializeUpdateInformations(string fileName)
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var stream = Helper.LoadFixture(fileName);

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var fixture = await reader.ReadToEndAsync();

                    var result = pipedrive.Webhook.ParseWebhookPersonResponse(fixture);

                    Assert.NotEmpty(result.Meta.Action);
                    Assert.NotEqual(0, result.Current.Id);
                }
            }
        }
    }
}
