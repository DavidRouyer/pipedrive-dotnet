using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class FiltersClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveFilters()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var filters = await pipedrive.Filter.GetAll(FilterFilters.None);

                Assert.True(filters.Count >= 1);
                Assert.Equal("All open deals", filters[0].Name);
                Assert.True(filters[0].ActiveFlag);
            }
        }

        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveFilter()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var filter = await pipedrive.Filter.Get(1);

                Assert.True(filter.ActiveFlag);
                Assert.Equal("All open deals", filter.Name);
            }
        }
    }
}
