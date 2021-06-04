using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class OrganizationFieldsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveOrganizationFields()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var organizationFields = await pipedrive.OrganizationField.GetAll();

                Assert.True(organizationFields.Count >= 6);
                Assert.True(organizationFields[0].ActiveFlag);
                Assert.True(organizationFields[0].AddVisibleFlag);
                Assert.True(organizationFields[1].ActiveFlag);
                Assert.True(organizationFields[1].AddVisibleFlag);
            }
        }

        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveOrganizationField()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var organizationField = await pipedrive.OrganizationField.Get(3993);

                Assert.True(organizationField.ActiveFlag);
                Assert.True(organizationField.AddVisibleFlag);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.OrganizationField;

                var newOrganizationField = new NewOrganizationField("name", FieldType.time);

                var organizationField = await fixture.Create(newOrganizationField);
                Assert.NotNull(organizationField);

                var retrieved = await fixture.Get(organizationField.Id.Value);
                Assert.NotNull(retrieved);

                // Cleanup
                await fixture.Delete(organizationField.Id.Value);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.OrganizationField;

                var newOrganizationField = new NewOrganizationField("new-name", FieldType.varchar);
                var organizationField = await fixture.Create(newOrganizationField);

                var editOrganizationField = organizationField.ToUpdate();
                editOrganizationField.Name = "updated-name";

                var updatedOrganizationField = await fixture.Edit(organizationField.Id.Value, editOrganizationField);

                Assert.Equal("updated-name", updatedOrganizationField.Name);
                Assert.Equal(FieldType.varchar, updatedOrganizationField.FieldType);

                // Cleanup
                await fixture.Delete(updatedOrganizationField.Id.Value);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.OrganizationField;

                var newOrganizationField = new NewOrganizationField("new-name", FieldType.varchar_auto);
                var organizationField = await fixture.Create(newOrganizationField);

                var createdOrganizationField = await fixture.Get(organizationField.Id.Value);

                Assert.NotNull(createdOrganizationField);

                await fixture.Delete(createdOrganizationField.Id.Value);

                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(createdOrganizationField.Id.Value));
            }
        }

        public class TheDeleteMultipleMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.OrganizationField;

                var organizationField1 = await fixture.Create(new NewOrganizationField("new-subject1", FieldType.text));
                var organizationField2 = await fixture.Create(new NewOrganizationField("new-subject2", FieldType.text));

                var createdOrganizationField1 = await fixture.Get(organizationField1.Id.Value);
                var createdOrganizationField2 = await fixture.Get(organizationField2.Id.Value);

                Assert.NotNull(createdOrganizationField1);
                Assert.NotNull(createdOrganizationField2);

                await fixture.Delete(new List<long>() { createdOrganizationField1.Id.Value, createdOrganizationField2.Id.Value });

                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(createdOrganizationField1.Id.Value));
                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(createdOrganizationField2.Id.Value));
            }
        }
    }
}
