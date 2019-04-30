using System;
using System.Net.Http;
using System.Threading.Tasks;
using Pipedrive.Helpers;

namespace Pipedrive.Clients
{
    public class OAuthClient : IOAuthClient
    {
        readonly IConnection connection;
        readonly Uri hostAddress;

        /// <summary>
        /// Create an instance of the OAuthClient
        /// </summary>
        /// <param name="connection">The underlying connection to use</param>
        public OAuthClient(IConnection connection)
        {
            Ensure.ArgumentNotNull(connection, nameof(connection));

            this.connection = connection;

            hostAddress = new Uri("https://oauth.pipedrive.com");
        }

        /// <summary>
        /// Gets the URL used in the first step of the web flow. The Web application should redirect to this URL.
        /// </summary>
        /// <param name="request">Parameters to the Oauth web flow login url</param>
        /// <returns></returns>
        public Uri GetPipedriveLoginUrl(OAuthLoginRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            return new Uri(hostAddress, ApiUrls.OAuthAuthorize())
                .ApplyParameters(request.ToParametersDictionary());
        }

        /// <summary>
        /// Makes a request to get an access token using the code returned when pipedrive.com redirects back from the URL
        /// <see cref="GetPipedriveLoginUrl">Pipedrive login url</see> to the application.
        /// </summary>
        /// <remarks>
        /// If the user accepts your request, Pipedrive redirects back to your site with a temporary code in a code
        /// parameter as well as the state you provided in the previous step in a state parameter. If the states don’t
        /// match, the request has been created by a third party and the process should be aborted. Exchange this for
        /// an access token using this method.
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<OAuthToken> CreateAccessToken(OAuthAccessTokenRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            var endPoint = ApiUrls.OAuthAccessToken();

            var parameters = request.ToParametersDictionary();
            parameters.TryGetValue("client_id", out var clientId);
            parameters.TryGetValue("client_secret", out var clientSecret);

            var body = new FormUrlEncodedContent(parameters);

            connection.Credentials = new Credentials(clientId, clientSecret, AuthenticationType.Basic);

            var response = await connection.Post<OAuthToken>(endPoint, body, "application/json", null, hostAddress).ConfigureAwait(false);
            return response.Body;
        }

        public async Task<OAuthToken> RefreshAccessToken(OAuthRefreshTokenRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            var endPoint = ApiUrls.OAuthAccessToken();

            var parameters = request.ToParametersDictionary();
            parameters.TryGetValue("client_id", out var clientId);
            parameters.TryGetValue("client_secret", out var clientSecret);

            var body = new FormUrlEncodedContent(parameters);

            connection.Credentials = new Credentials(clientId, clientSecret, AuthenticationType.Basic);

            var response = await connection.Post<OAuthToken>(endPoint, body, "application/json", null, hostAddress).ConfigureAwait(false);
            return response.Body;
        }
        
        public async Task RevokeToken(OAuthRevokeTokenRequest request)
        {
            Ensure.ArgumentNotNull(request, nameof(request));

            var endPoint = ApiUrls.OAuthRevokeToken();

            var parameters = request.ToParametersDictionary();
            parameters.TryGetValue("client_id", out var clientId);
            parameters.TryGetValue("client_secret", out var clientSecret);

            var body = new FormUrlEncodedContent(parameters);

            connection.Credentials = new Credentials(clientId, clientSecret, AuthenticationType.Basic);

            await connection.Post(endPoint, body, "application/json").ConfigureAwait(false);
        }
    }
}
