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

        public class TheSearchMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveOrganizations()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var organizations = await pipedrive.Organization.Search("david rouyer", OrganizationSearchFilters.None);

                Assert.True(organizations.Count == 1);
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

        public class TheGetPersonsMethod
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

                var persons = await pipedrive.Organization.GetPersons(5, options);
                Assert.Equal(3, persons.Count);
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

                var persons = await pipedrive.Organization.GetPersons(5, options);
                Assert.Equal(2, persons.Count);
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

                var firstPage = await pipedrive.Organization.GetPersons(5, startOptions);

                var skipStartOptions = new OrganizationFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Organization.GetPersons(5, skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheGetFollowersMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCount()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var followers = await pipedrive.Organization.GetFollowers(1);
                Assert.Equal(1, followers.Count);
            }
        }

        public class TheAddFollowerMethod
        {
            [IntegrationTest]
            public async Task CanAddFollower()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Organization;

                var addFollower = await fixture.AddFollower(1, 595707);
                Assert.NotNull(addFollower);
            }
        }

        public class TheDeleteFollowerMethod
        {
            [IntegrationTest]
            public async Task CanDeleteFollower()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Organization;

                await fixture.DeleteFollower(1, 461);
            }
        }

        public class TheGetActivitiesMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new OrganizationActivityFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var organizationActivities = await pipedrive.Organization.GetActivities(5, options);
                Assert.Equal(3, organizationActivities.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new OrganizationActivityFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var activities = await pipedrive.Organization.GetActivities(5, options);
                Assert.Equal(2, activities.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new OrganizationActivityFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Organization.GetActivities(5, startOptions);

                var skipStartOptions = new OrganizationActivityFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Organization.GetActivities(1, skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheGetFilesMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new OrganizationFileFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var organizationFiles = await pipedrive.Organization.GetFiles(5, options);
                Assert.Equal(3, organizationFiles.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new OrganizationFileFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var files = await pipedrive.Organization.GetFiles(5, options);
                Assert.Equal(2, files.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new OrganizationFileFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Organization.GetFiles(5, startOptions);

                var skipStartOptions = new OrganizationFileFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Organization.GetFiles(5, skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheGetUpdatesMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new OrganizationUpdateFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var organizationUpdates = await pipedrive.Organization.GetUpdates(5, options);
                Assert.Equal(3, organizationUpdates.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new OrganizationUpdateFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var updates = await pipedrive.Organization.GetUpdates(5, options);
                Assert.Equal(2, updates.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new OrganizationUpdateFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Organization.GetUpdates(5, startOptions);

                var skipStartOptions = new OrganizationUpdateFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Organization.GetUpdates(5, skipStartOptions);

                Assert.NotEqual(firstPage[0].Data.Id, secondPage[0].Data.Id);
            }
        }
    }
}
