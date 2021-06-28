using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class LeadLabelsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveDealFields()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var leadLabels = await pipedrive.LeadLabel.GetAll();

                Assert.True(leadLabels.Count >= 3);
                Assert.Equal("red", leadLabels[0].Color);
                Assert.Equal("Hot", leadLabels[0].Name);
            }
        }
    }
}
