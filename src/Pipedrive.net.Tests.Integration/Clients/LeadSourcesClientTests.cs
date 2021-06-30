using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class LeadSourcesClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveLeadSources()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var leadSources = await pipedrive.LeadSource.GetAll();

                Assert.True(leadSources.Count >= 3);
                Assert.Equal("Manually created", leadSources[0].Name);
            }
        }
    }
}
