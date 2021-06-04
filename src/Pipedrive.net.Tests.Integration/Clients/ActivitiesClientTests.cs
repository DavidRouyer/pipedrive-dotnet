using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class ActivitiesClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var filters = new ActivityFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var activities = await pipedrive.Activity.GetAll(filters);
                Assert.Equal(3, activities.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var filters = new ActivityFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var activities = await pipedrive.Activity.GetAll(filters);
                Assert.Equal(2, activities.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startFilters = new ActivityFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Activity.GetAll(startFilters);

                var skipStartFilters = new ActivityFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Activity.GetAll(skipStartFilters);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Activity;

                var newActivity = new NewActivity("new-subject", "call");
                newActivity.DueDate = DateTime.UtcNow.AddDays(2);

                var activity = await fixture.Create(newActivity);
                Assert.NotNull(activity);

                var retrieved = await fixture.Get(activity.Id);
                Assert.NotNull(retrieved);
                Assert.Equal(DateTime.UtcNow.Date.AddDays(2), retrieved.DueDate.Value.Date);

                // Cleanup
                await fixture.Delete(activity.Id);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Activity;

                var newActivity = new NewActivity("new-subject", "meeting");
                var activity = await fixture.Create(newActivity);

                var editActivity = activity.ToUpdate();
                editActivity.Subject = "updated-subject";
                editActivity.Type = "lunch";
                editActivity.DueDate = DateTime.UtcNow.AddDays(5);

                var updatedActivity = await fixture.Edit(activity.Id, editActivity);

                Assert.Equal("updated-subject", updatedActivity.Subject);
                Assert.Equal("lunch", updatedActivity.Type);
                Assert.Equal(DateTime.UtcNow.Date.AddDays(5), updatedActivity.DueDate.Value.Date);

                // Cleanup
                await fixture.Delete(updatedActivity.Id);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Activity;

                var newActivity = new NewActivity("new-subject", "email");
                var activity = await fixture.Create(newActivity);

                var createdActivity = await fixture.Get(activity.Id);

                Assert.NotNull(createdActivity);

                await fixture.Delete(createdActivity.Id);

                var deletedActivity = await fixture.Get(createdActivity.Id);

                Assert.False(deletedActivity.ActiveFlag);
            }
        }

        public class TheDeleteMultipleMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Activity;

                var activity1 = await fixture.Create(new NewActivity("new-subject1", "email"));
                var activity2 = await fixture.Create(new NewActivity("new-subject2", "email"));

                var createdActivity1 = await fixture.Get(activity1.Id);
                var createdActivity2 = await fixture.Get(activity2.Id);

                Assert.NotNull(createdActivity1);
                Assert.NotNull(createdActivity2);

                await fixture.Delete(new List<long>() { createdActivity1.Id, createdActivity2.Id });

                var deletedActivity1 = await fixture.Get(createdActivity1.Id);
                var deletedActivity2 = await fixture.Get(createdActivity2.Id);

                Assert.False(deletedActivity1.ActiveFlag);
                Assert.False(deletedActivity2.ActiveFlag);
            }
        }
    }
}
