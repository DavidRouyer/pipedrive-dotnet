﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class PersonsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new PersonFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var persons = await pipedrive.Person.GetAll(options);
                Assert.Equal(3, persons.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new PersonFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var persons = await pipedrive.Person.GetAll(options);
                Assert.Equal(2, persons.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new PersonFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Person.GetAll(startOptions);

                var skipStartOptions = new PersonFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Person.GetAll(skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task CanRetrievePerson()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var person = await pipedrive.Person.Get(141);

                Assert.Equal("david@hopfab.com", person.Email[0].Value);
            }
        }

        public class TheSearchMethod
        {
            [IntegrationTest]
            public async Task CanRetrievePersons()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var persons = await pipedrive.Person.Search("david rouyer", PersonSearchFilters.None);

                Assert.True(persons.Count == 1);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Person;

                var newPerson = new NewPerson("name");

                var person = await fixture.Create(newPerson);
                Assert.NotNull(person);

                var retrieved = await fixture.Get(person.Id);
                Assert.NotNull(retrieved);

                // Cleanup
                await fixture.Delete(person.Id);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Person;

                var newPerson = new NewPerson("new-name");
                var person = await fixture.Create(newPerson);

                var editPerson = person.ToUpdate();
                editPerson.Name = "updated-name";
                editPerson.Email = new List<Email>
                {
                    { new Email { Value = "test@example.com", Primary = true } }
                };

                var updatedPerson = await fixture.Edit(person.Id, editPerson);

                Assert.Equal("updated-name", updatedPerson.Name);
                Assert.Equal("test@example.com", updatedPerson.Email[0].Value);
                Assert.True(updatedPerson.Email[0].Primary);

                // Cleanup
                await fixture.Delete(updatedPerson.Id);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Person;

                var newPerson = new NewPerson("new-name");
                var person = await fixture.Create(newPerson);

                var createdPerson = await fixture.Get(person.Id);

                Assert.NotNull(createdPerson);

                await fixture.Delete(createdPerson.Id);

                var deletedPerson = await fixture.Get(createdPerson.Id);

                Assert.False(deletedPerson.ActiveFlag);
            }
        }

        public class TheGetDealsMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new PersonDealFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var stageDeals = await pipedrive.Person.GetDeals(6, options);
                Assert.Equal(3, stageDeals.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new PersonDealFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var deals = await pipedrive.Person.GetDeals(6, options);
                Assert.Equal(2, deals.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new PersonDealFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Person.GetDeals(6, startOptions);

                var skipStartOptions = new PersonDealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Person.GetDeals(6, skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheGetActivitiesMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new PersonActivityFilters
                {
                    PageSize = 3,
                };

                var stageActivities = await pipedrive.Person.GetActivities(6, options);
                Assert.Equal(3, stageActivities.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new PersonActivityFilters
                {
                    PageSize = 2,
                    StartPage = 1
                };

                var activities = await pipedrive.Person.GetActivities(6, options);
                Assert.Equal(2, activities.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new PersonActivityFilters
                {
                    PageSize = 1,
                };

                var firstPage = await pipedrive.Person.GetActivities(6, startOptions);

                var skipStartOptions = new PersonActivityFilters
                {
                    PageSize = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Person.GetActivities(6, skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheGetFilesMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new PersonFileFilters
                {
                    PageSize = 3,
                };

                var personFiles = await pipedrive.Person.GetFiles(6, options);
                Assert.Equal(3, personFiles.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new PersonFileFilters
                {
                    PageSize = 2,
                    StartPage = 1
                };

                var files = await pipedrive.Person.GetFiles(6, options);
                Assert.Equal(2, files.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new PersonFileFilters
                {
                    PageSize = 1,
                };

                var firstPage = await pipedrive.Person.GetFiles(6, startOptions);

                var skipStartOptions = new PersonFileFilters
                {
                    PageSize = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Person.GetFiles(6, skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheGetFollowersMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCount()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var followers = await pipedrive.Person.GetFollowers(1);
                Assert.Equal(1, followers.Count);
            }
        }

        public class TheAddFollowerMethod
        {
            [IntegrationTest]
            public async Task CanAddFollower()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Person;

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
                var fixture = pipedrive.Person;

                await fixture.DeleteFollower(1, 461);
            }
        }
    }
}
