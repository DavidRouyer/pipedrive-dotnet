using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class PersonFieldsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task CanRetrievePersonFields()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var personFields = await pipedrive.PersonField.GetAll();

                Assert.True(personFields.Count >= 6);
                Assert.True(personFields[0].ActiveFlag);
                Assert.True(personFields[0].AddVisibleFlag);
                Assert.True(personFields[1].ActiveFlag);
                Assert.True(personFields[1].AddVisibleFlag);
            }
        }

        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task CanRetrievePersonField()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var personField = await pipedrive.PersonField.Get(9038);

                Assert.True(personField.ActiveFlag);
                Assert.True(personField.AddVisibleFlag);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.PersonField;

                var newPersonField = new NewPersonField("name", FieldType.time);

                var personField = await fixture.Create(newPersonField);
                Assert.NotNull(personField);

                var retrieved = await fixture.Get(personField.Id.Value);
                Assert.NotNull(retrieved);

                // Cleanup
                await fixture.Delete(personField.Id.Value);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.PersonField;

                var newPersonField = new NewPersonField("new-name", FieldType.varchar);
                var personField = await fixture.Create(newPersonField);

                var editPersonField = personField.ToUpdate();
                editPersonField.Name = "updated-name";

                var updatedPersonField = await fixture.Edit(personField.Id.Value, editPersonField);

                Assert.Equal("updated-name", updatedPersonField.Name);
                Assert.Equal(FieldType.varchar, updatedPersonField.FieldType);

                // Cleanup
                await fixture.Delete(updatedPersonField.Id.Value);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.PersonField;

                var newPersonField = new NewPersonField("new-name", FieldType.varchar_auto);
                var personField = await fixture.Create(newPersonField);

                var createdPersonField = await fixture.Get(personField.Id.Value);

                Assert.NotNull(createdPersonField);

                await fixture.Delete(createdPersonField.Id.Value);

                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(createdPersonField.Id.Value));
            }
        }

        public class TheDeleteMultipleMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.PersonField;

                var personField1 = await fixture.Create(new NewPersonField("new-subject1", FieldType.text));
                var personField2 = await fixture.Create(new NewPersonField("new-subject2", FieldType.text));

                var createdPersonField1 = await fixture.Get(personField1.Id.Value);
                var createdPersonField2 = await fixture.Get(personField2.Id.Value);

                Assert.NotNull(createdPersonField1);
                Assert.NotNull(createdPersonField2);

                await fixture.Delete(new List<long>() { createdPersonField1.Id.Value, createdPersonField2.Id.Value });

                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(createdPersonField1.Id.Value));
                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(createdPersonField2.Id.Value));
            }
        }
    }
}
