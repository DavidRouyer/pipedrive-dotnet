using System;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class LeadsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new LeadFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var leads = await pipedrive.Lead.GetAll(options);
                Assert.Equal(3, leads.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new LeadFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var leads = await pipedrive.Lead.GetAll(options);
                Assert.Equal(2, leads.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new LeadFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Lead.GetAll(startOptions);

                var skipStartOptions = new LeadFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Lead.GetAll(skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveDeal()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var lead = await pipedrive.Lead.Get(new Guid("42b9e030-0e5c-11eb-8c38-a7dff179fdd2"));

                Assert.False(lead.IsArchived);
            }
        }
    }
}
