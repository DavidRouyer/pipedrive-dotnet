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

                var stages = await pipedrive.Stage.GetAll();

                Assert.True(stages.Count >= 1);
                Assert.True(stages[0].ActiveFlag);
                Assert.False(stages[0].RottenFlag);
                Assert.True(stages[1].ActiveFlag);
                Assert.False(stages[1].RottenFlag);
            }
        }

        public class TheGetAllForPipelineIdMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveStages()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var stages = await pipedrive.Stage.GetAllForPipelineId(1);

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

                // Cleanup
                await fixture.Delete(stage.Id);
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

                // Cleanup
                await fixture.Delete(updatedStage.Id);
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

        public class TheGetDealsMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new StageDealFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var stageDeals = await pipedrive.Stage.GetDeals(1, options);
                Assert.Equal(3, stageDeals.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new StageDealFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var deals = await pipedrive.Stage.GetDeals(1, options);
                Assert.Equal(2, deals.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new StageDealFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Stage.GetDeals(1, startOptions);

                var skipStartOptions = new StageDealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Stage.GetDeals(1, skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }
    }
}
