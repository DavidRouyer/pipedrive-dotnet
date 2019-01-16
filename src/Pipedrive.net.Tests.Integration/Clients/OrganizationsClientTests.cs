using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class OrganizationsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new OrganizationFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var organizations = await pipedrive.Organization.GetAll(options);
                Assert.Equal(3, organizations.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new OrganizationFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var organizations = await pipedrive.Organization.GetAll(options);
                Assert.Equal(2, organizations.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new OrganizationFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Organization.GetAll(startOptions);

                var skipStartOptions = new OrganizationFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Organization.GetAll(skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveOrganization()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var person = await pipedrive.Organization.Get(217);

                Assert.Equal("david rouyer", person.Name);
            }
        }

        public class TheGetByNameMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveOrganizations()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var organizations = await pipedrive.Organization.GetByName("david rouyer");

                Assert.True(organizations.Count == 1);
                Assert.Equal("david rouyer", organizations[0].Name);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Organization;

                var newOrganization = new NewOrganization("name");

                var organization = await fixture.Create(newOrganization);
                Assert.NotNull(organization);

                var retrieved = await fixture.Get(organization.Id);
                Assert.NotNull(retrieved);

                // Cleanup
                await fixture.Delete(organization.Id);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Organization;

                var newOrganization = new NewOrganization("new-name");
                var organization = await fixture.Create(newOrganization);

                var editOrganization = organization.ToUpdate();
                editOrganization.Name = "updated-name";
                editOrganization.VisibleTo = Visibility.shared;

                var updatedOrganization = await fixture.Edit(organization.Id, editOrganization);

                Assert.Equal("updated-name", updatedOrganization.Name);
                Assert.Equal(Visibility.shared, updatedOrganization.VisibleTo);

                // Cleanup
                await fixture.Delete(updatedOrganization.Id);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Organization;

                var newOrganization = new NewOrganization("new-name");
                var organization = await fixture.Create(newOrganization);

                var createdOrganization = await fixture.Get(organization.Id);

                Assert.NotNull(createdOrganization);

                await fixture.Delete(createdOrganization.Id);

                var deletedOrganization = await fixture.Get(createdOrganization.Id);

                Assert.False(deletedOrganization.ActiveFlag);
            }
        }

        public class TheGetDealsMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new OrganizationDealFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var stageDeals = await pipedrive.Organization.GetDeals(5, options);
                Assert.Equal(3, stageDeals.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new OrganizationDealFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var deals = await pipedrive.Organization.GetDeals(5, options);
                Assert.Equal(2, deals.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new OrganizationDealFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Organization.GetDeals(5, startOptions);

                var skipStartOptions = new OrganizationDealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Organization.GetDeals(5, skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }
    }
}
