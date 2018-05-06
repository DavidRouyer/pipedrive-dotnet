using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class FilesClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var filters = new FileFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var files = await pipedrive.File.GetAll(filters);
                Assert.Equal(3, files.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var filters = new FileFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var files = await pipedrive.File.GetAll(filters);
                Assert.Equal(2, files.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startFilters = new FileFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.File.GetAll(startFilters);

                var skipStartFilters = new FileFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.File.GetAll(skipStartFilters);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        /*public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.File;

                var imageUrl = @"./Content/image.jpg";
                FileStream reader = new FileStream(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), imageUrl), FileMode.Open);

                var newFile = new NewFile(reader);

                var file = await fixture.Create(newFile);
                Assert.NotNull(file);

                var retrieved = await fixture.Get(file.Id);
                Assert.NotNull(retrieved);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.File;

                byte[] data = System.Convert.FromBase64String("R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==");
                var newFile = new NewFile(new MemoryStream(data));
                var file = await fixture.Create(newFile);

                var editFile = file.ToUpdate();
                editFile.Name = "updated-name";
                editFile.Description = "updated-description";

                var updatedFile = await fixture.Edit(file.Id, editFile);

                Assert.Equal("updated-name", updatedFile.Name);
                Assert.Equal("updated-description", updatedFile.Description);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.File;

                byte[] data = System.Convert.FromBase64String("R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==");
                var newFile = new NewFile(new MemoryStream(data));
                var file = await fixture.Create(newFile);

                var createdFile = await fixture.Get(file.Id);

                Assert.NotNull(createdFile);

                await fixture.Delete(createdFile.Id);

                var deletedFile =  await fixture.Get(createdFile.Id);

                Assert.False(deletedFile.ActiveFlag);
            }
        }*/
    }
}
