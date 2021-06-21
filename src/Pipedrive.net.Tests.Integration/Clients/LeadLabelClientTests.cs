using System;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class LeadLabelClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCount()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var leadLabels = await pipedrive.LeadLabels.GetAll();
                Assert.NotEqual(0, leadLabels.Count);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.LeadLabels;

                var leadLabel = await fixture.Create(new NewLeadLabel
                {
                    Name = Guid.NewGuid().ToString(),
                    Color = "blue"
                });
                Assert.NotNull(leadLabel);

                var allLeadLabels = await fixture.GetAll();

                Assert.Contains(allLeadLabels, l => l.Id == leadLabel.Id);

                // Cleanup
                await fixture.Delete(leadLabel.Id);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.LeadLabels;
                var nameOfNewLabel = Guid.NewGuid().ToString();

                var createdLeadLabel = await fixture.Create(new NewLeadLabel
                {
                    Name = nameOfNewLabel,
                    Color = "blue"
                });

                Assert.NotNull(createdLeadLabel);

                await fixture.Delete(createdLeadLabel.Id);

                var allLeadLabels = await fixture.GetAll();

                Assert.DoesNotContain(allLeadLabels, l => l.Id == createdLeadLabel.Id);
            }
        }
    }
}
