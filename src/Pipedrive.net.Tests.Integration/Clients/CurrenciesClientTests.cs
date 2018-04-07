using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class CurrenciesClientTests
    {
        [IntegrationTest]
        public async Task CanRetrieveCurrencies()
        {
            var pipedrive = Helper.GetAuthenticatedClient();

            var currencies = await pipedrive.Currency.GetAll();
            Assert.Equal(178, currencies.Count);
            Assert.True(currencies[0].ActiveFlag);
            Assert.False(currencies[0].IsCustomFlag);
            Assert.True(currencies[1].ActiveFlag);
            Assert.False(currencies[1].IsCustomFlag);
        }

        [IntegrationTest]
        public async Task CanRetrieveCurrenciesByTerm()
        {
            var pipedrive = Helper.GetAuthenticatedClient();

            var currencies = await pipedrive.Currency.GetAll("EUR");
            Assert.Equal(1, currencies.Count);
            Assert.False(currencies[0].IsCustomFlag);
            Assert.True(currencies[0].ActiveFlag);
        }
    }
}
