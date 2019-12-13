﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class WebhooksClientTests
    {
        public class TheParseWebhookDealResponseMethod
        {
            [Fact]
            public async Task DeserializeCreateInformations()
            {
                var stream = Helper.LoadFixture("webhook_deal_create.json");

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var fixture = await reader.ReadToEndAsync();

                    var webhookClient = new WebhooksClient();
                    var result = webhookClient.ParseWebhookDealResponse(fixture);
                }
            }

            [Fact]
            public async Task DeserializeUpdateInformations()
            {
                var stream = Helper.LoadFixture("webhook_deal_update.json");

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var fixture = await reader.ReadToEndAsync();

                    var webhookClient = new WebhooksClient();
                    var result = webhookClient.ParseWebhookDealResponse(fixture);
                }
            }
        }

        public class TheParseWebhookActivityResponseMethod
        {
            [Fact]
            public async Task DeserializeUpdateInformations()
            {
                var stream = Helper.LoadFixture("webhook_activity_update.json");

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var fixture = await reader.ReadToEndAsync();

                    var webhookClient = new WebhooksClient();
                    var result = webhookClient.ParseWebhookActivityResponse(fixture);
                }
            }
        }

        public class TheParseWebhookOrganizationResponseMethod
        {
            [Fact]
            public async Task DeserializeCreateInformations()
            {
                var stream = Helper.LoadFixture("webhook_organization_create.json");

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var fixture = await reader.ReadToEndAsync();

                    var webhookClient = new WebhooksClient();
                    var result = webhookClient.ParseWebhookOrganizationResponse(fixture);
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
                var stream = Helper.LoadFixture(fileName);

                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    var fixture = await reader.ReadToEndAsync();

                    var webhookClient = new WebhooksClient();
                    var result = webhookClient.ParseWebhookPersonResponse(fixture);

                    Assert.NotEmpty(result.Meta.Action);
                    Assert.NotEqual(0, result.Current.Id);
                }
            }
        }
    }
}
