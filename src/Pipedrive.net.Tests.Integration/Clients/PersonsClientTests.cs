using System.Collections.Generic;
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
    }
}
