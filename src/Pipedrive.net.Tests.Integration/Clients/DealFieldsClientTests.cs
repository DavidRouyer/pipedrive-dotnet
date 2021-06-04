using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class DealFieldsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveDealFields()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var dealFields = await pipedrive.DealField.GetAll();

                Assert.True(dealFields.Count >= 6);
                Assert.True(dealFields[0].ActiveFlag);
                Assert.False(dealFields[0].AddVisibleFlag);
                Assert.True(dealFields[1].ActiveFlag);
                Assert.False(dealFields[1].AddVisibleFlag);
            }
        }

        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveDealField()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var dealField = await pipedrive.DealField.Get(12451);

                Assert.True(dealField.ActiveFlag);
                Assert.False(dealField.AddVisibleFlag);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.DealField;

                var newDealField = new NewDealField("name", FieldType.time);

                var dealField = await fixture.Create(newDealField);
                Assert.NotNull(dealField);

                var retrieved = await fixture.Get(dealField.Id.Value);
                Assert.NotNull(retrieved);

                // Cleanup
                await fixture.Delete(dealField.Id.Value);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.DealField;

                var newDealField = new NewDealField("new-name", FieldType.varchar);
                var dealField = await fixture.Create(newDealField);

                var editDealField = dealField.ToUpdate();
                editDealField.Name = "updated-name";

                var updatedDealField = await fixture.Edit(dealField.Id.Value, editDealField);

                Assert.Equal("updated-name", updatedDealField.Name);
                Assert.Equal(FieldType.varchar, updatedDealField.FieldType);

                // Cleanup
                await fixture.Delete(updatedDealField.Id.Value);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.DealField;

                var newDealField = new NewDealField("new-name", FieldType.varchar_auto);
                var dealField = await fixture.Create(newDealField);

                var createdDealField = await fixture.Get(dealField.Id.Value);

                Assert.NotNull(createdDealField);

                await fixture.Delete(createdDealField.Id.Value);

                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(createdDealField.Id.Value));
            }
        }

        public class TheDeleteMultipleMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.DealField;

                var dealField1 = await fixture.Create(new NewDealField("new-subject1", FieldType.text));
                var dealField2 = await fixture.Create(new NewDealField("new-subject2", FieldType.text));

                var createdDealField1 = await fixture.Get(dealField1.Id.Value);
                var createdDealField2 = await fixture.Get(dealField2.Id.Value);

                Assert.NotNull(createdDealField1);
                Assert.NotNull(createdDealField2);

                await fixture.Delete(new List<long>() { createdDealField1.Id.Value, createdDealField2.Id.Value });

                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(createdDealField1.Id.Value));
                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(createdDealField2.Id.Value));
            }
        }
    }
}
