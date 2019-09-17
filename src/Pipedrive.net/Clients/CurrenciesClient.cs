using System.Collections.Generic;
using System.Threading.Tasks;
using Pipedrive.Helpers;

namespace Pipedrive
{
    /// <summary>
    /// A client for Pipedrive's Currency API.
    /// </summary>
    /// <remarks>
    /// See the <a href="https://developers.pipedrive.com/docs/api/v1/#!/Currencies">Currency API documentation</a> for more information.
    public class CurrenciesClient : ApiClient, ICurrenciesClient
    {
        /// <summary>
        /// Initializes a new Currency API client.
        /// </summary>
        /// <param name="apiConnection">An API connection</param>
        public CurrenciesClient(IApiConnection apiConnection) : base(apiConnection)
        {
        }

        public Task<IReadOnlyList<Currency>> GetAll()
        {
            return ApiConnection.GetAll<Currency>(ApiUrls.Currencies());
        }

        public Task<IReadOnlyList<Currency>> GetAll(string term)
        {
            Ensure.ArgumentNotNullOrEmptyString(term, nameof(term));

            var parameters = new Dictionary<string, string>
            {
                { "term", term }
            };

            return ApiConnection.GetAll<Currency>(ApiUrls.Currencies(), parameters);
        }
    }
}
