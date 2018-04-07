using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class ActivityTypesClientTests
    {
        [IntegrationTest]
        public async Task CanRetrieveCurrencies()
        {
            var pipedrive = Helper.GetAuthenticatedClient();

            var activityTypes = await pipedrive.ActivityType.GetAll();
            Assert.Equal(6, activityTypes.Count);
            Assert.True(activityTypes[0].ActiveFlag);
            Assert.False(activityTypes[0].IsCustomFlag);
            Assert.True(activityTypes[1].ActiveFlag);
            Assert.False(activityTypes[1].IsCustomFlag);
        }
    }
}
