using System.Collections.Generic;
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

        public class TheDeleteMultipleMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.ActivityType;

                var activityType1 = await fixture.Create(new NewActivityType("new-activityType-1", ActivityTypeIcon.Addressbook));
                var activityType2 = await fixture.Create(new NewActivityType("new-activityType-2", ActivityTypeIcon.Addressbook));

                var createdActivityTypes = await fixture.GetAll();
                var createdActivityType1 = createdActivityTypes.Where(at => at.Name == "new-activityType-1").FirstOrDefault();
                var createdActivityType2 = createdActivityTypes.Where(at => at.Name == "new-activityType-2").FirstOrDefault();

                Assert.NotNull(createdActivityType1);
                Assert.NotNull(createdActivityType2);

                await fixture.Delete(new List<long>() { createdActivityType1.Id, createdActivityType2.Id });

                var deletedActivityTypes = await fixture.GetAll();
                var deletedActivityType1 = deletedActivityTypes.Where(at => at.Name == "new-activityType-1").FirstOrDefault();
                var deletedActivityType2 = deletedActivityTypes.Where(at => at.Name == "new-activityType-2").FirstOrDefault();

                Assert.False(deletedActivityType1.ActiveFlag);
                Assert.False(deletedActivityType2.ActiveFlag);
            }
        }
    }
}
