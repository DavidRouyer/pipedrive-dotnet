using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class StagesClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveStages()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var stages = await pipedrive.Stage.GetAll(1);

                Assert.True(stages.Count >= 1);
                Assert.True(stages[0].ActiveFlag);
                Assert.False(stages[0].RottenFlag);
                Assert.True(stages[1].ActiveFlag);
                Assert.False(stages[1].RottenFlag);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Stage;

                var newStage = new NewStage("name", 1);

                var stage = await fixture.Create(newStage);
                Assert.NotNull(stage);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Stage;

                var newStage = new NewStage("new-name", 1);
                var stage = await fixture.Create(newStage);

                var editStage = stage.ToUpdate();
                editStage.Name = "updated-name";
                editStage.RottenFlag = true;
                editStage.RottenDays = 100;

                var updatedStage = await fixture.Edit(stage.Id, editStage);

                Assert.Equal("updated-name", updatedStage.Name);
                Assert.True(updatedStage.RottenFlag);
                Assert.Equal(100, updatedStage.RottenDays);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Stage;

                var newStage = new NewStage("new-name", 1);
                var stage = await fixture.Create(newStage);

                var createdStage = await fixture.Get(stage.Id);

                Assert.NotNull(createdStage);

                await fixture.Delete(createdStage.Id);

                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Get(stage.Id));
            }
        }
    }
}
