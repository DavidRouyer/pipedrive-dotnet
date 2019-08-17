using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class ActivityFieldsClientTests
    {
        [IntegrationTest]
        public async Task ReturnsCorrectCountWithoutStart()
        {
            var pipedrive = Helper.GetAuthenticatedClient();

            var options = new ApiOptions
            {
                PageSize = 20,
                PageCount = 1
            };

            var activityFields = await pipedrive.ActivityField.GetAll(options);
            Assert.Equal(20, activityFields.Count);
        }

        [IntegrationTest]
        public async Task ReturnsCorrectCountWithStart()
        {
            var pipedrive = Helper.GetAuthenticatedClient();

            var options = new ApiOptions
            {
                PageSize = 2,
                PageCount = 1,
                StartPage = 1
            };

            var activityFields = await pipedrive.ActivityField.GetAll(options);
            Assert.Equal(2, activityFields.Count);
        }

        [IntegrationTest]
        public async Task ReturnsDistinctInfosBasedOnStartPage()
        {
            var pipedrive = Helper.GetAuthenticatedClient();

            var startOptions = new ApiOptions
            {
                PageSize = 1,
                PageCount = 1
            };

            var firstPage = await pipedrive.ActivityField.GetAll(startOptions);

            var skipStartOptions = new ApiOptions
            {
                PageSize = 1,
                PageCount = 1,
                StartPage = 1
            };

            var secondPage = await pipedrive.ActivityField.GetAll(skipStartOptions);

            Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
        }
    }
}
