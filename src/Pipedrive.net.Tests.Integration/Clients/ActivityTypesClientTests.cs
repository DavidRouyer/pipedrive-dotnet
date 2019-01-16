using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class ActivityTypesClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveActivityTypes()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var activityTypes = await pipedrive.ActivityType.GetAll();

                Assert.True(activityTypes.Count >= 6);
                Assert.True(activityTypes[0].ActiveFlag);
                Assert.False(activityTypes[0].IsCustomFlag);
                Assert.True(activityTypes[1].ActiveFlag);
                Assert.False(activityTypes[1].IsCustomFlag);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.ActivityType;

                var newActivityType = new NewActivityType("name", ActivityTypeIcon.Addressbook);

                var activityType = await fixture.Create(newActivityType);
                Assert.NotNull(activityType);

                var retrievedAll = await fixture.GetAll();
                var retrieved = retrievedAll.Where(ac => ac.Name == "name").FirstOrDefault();
                Assert.NotNull(retrieved);

                // Cleanup
                await fixture.Delete(activityType.Id);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.ActivityType;

                var newActivityType = new NewActivityType("new-name", ActivityTypeIcon.Plane);
                var activityType = await fixture.Create(newActivityType);

                var editActivityType = activityType.ToUpdate();
                editActivityType.Name = "updated-name";
                editActivityType.IconKey = ActivityTypeIcon.Sound;

                var updatedActivityType = await fixture.Edit(activityType.Id, editActivityType);

                Assert.Equal("updated-name", updatedActivityType.Name);
                Assert.Equal(ActivityTypeIcon.Sound, updatedActivityType.IconKey);

                // Cleanup
                await fixture.Delete(updatedActivityType.Id);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.ActivityType;

                var newActivityType = new NewActivityType("new-name", ActivityTypeIcon.Signpost);
                var activityType = await fixture.Create(newActivityType);

                var createdActivityTypes = await fixture.GetAll();
                var createdActivityType = createdActivityTypes.Where(ac => ac.Name == "new-name").FirstOrDefault();

                Assert.NotNull(createdActivityType);

                await fixture.Delete(createdActivityType.Id);

                var deletedActivityTypes = await fixture.GetAll();
                var deletedActivityType = deletedActivityTypes.Where(ac => ac.Name == "new-name").FirstOrDefault();

                Assert.False(deletedActivityType.ActiveFlag);
            }
        }
    }
}
