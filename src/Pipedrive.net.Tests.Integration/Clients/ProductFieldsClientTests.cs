using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class ProductFieldsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveProductFields()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var personFields = await pipedrive.ProductField.GetAll();

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
            public async Task CanRetrieveProductFieldField()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var productField = await pipedrive.ProductField.Get(29);

                Assert.True(productField.ActiveFlag);
                Assert.True(productField.AddVisibleFlag);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.ProductField;

                var newProductField = new NewProductField("name", FieldType.time);

                var productField = await fixture.Create(newProductField);
                Assert.NotNull(productField);

                var retrieved = await fixture.Get(productField.Id);
                Assert.NotNull(retrieved);

                // Cleanup
                await fixture.Delete(productField.Id);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.ProductField;

                var newProductField = new NewProductField("new-name", FieldType.varchar);
                var productField = await fixture.Create(newProductField);

                var editProductField = productField.ToUpdate();
                editProductField.Name = "updated-name";

                var updatedProductField = await fixture.Edit(productField.Id, editProductField);

                Assert.Equal("updated-name", updatedProductField.Name);
                Assert.Equal(FieldType.varchar, updatedProductField.FieldType);

                // Cleanup
                await fixture.Delete(updatedProductField.Id);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.ProductField;

                var newProductField = new NewProductField("new-name", FieldType.varchar_auto);
                var productField = await fixture.Create(newProductField);

                var createdProductField = await fixture.Get(productField.Id);

                Assert.NotNull(createdProductField);

                await fixture.Delete(createdProductField.Id);

                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(createdProductField.Id));
            }
        }

        public class TheDeleteMultipleMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.ProductField;

                var productField1 = await fixture.Create(new NewProductField("new-subject1", FieldType.text));
                var productField2 = await fixture.Create(new NewProductField("new-subject2", FieldType.text));

                var createdProductField1 = await fixture.Get(productField1.Id);
                var createdProductField2 = await fixture.Get(productField2.Id);

                Assert.NotNull(createdProductField1);
                Assert.NotNull(createdProductField2);

                await fixture.Delete(new List<long>() { createdProductField1.Id, createdProductField2.Id });

                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(createdProductField1.Id));
                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(createdProductField2.Id));
            }
        }
    }
}
