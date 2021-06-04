using System.Diagnostics;
using System.Globalization;
using Pipedrive.Helpers;
using Pipedrive.Internal;

namespace Pipedrive
{
    /// <summary>
    /// Used to create an OAuth refresh token request.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class OAuthRefreshTokenRequest : RequestParameters
    {
        /// <summary>
        /// Creates an instance of the OAuth refresh token request with the required parameter.
        /// </summary>
        /// <param name="clientId">The client Id you received from Pipedrive when you registered the application.</param>
        /// <param name="clientSecret">The client secret you received from Pipedrive when you registered the application.</param>
        /// <param name="refreshToken">The refresh token you received from Pipedrive when requesting the <see cref="IOAuthClient.CreateAccessToken"> endpoint.</param>
        public OAuthRefreshTokenRequest(string clientId, string clientSecret, string refreshToken)
        {
            Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
            Ensure.ArgumentNotNullOrEmptyString(clientSecret, nameof(clientSecret));
            Ensure.ArgumentNotNullOrEmptyString(refreshToken, nameof(refreshToken));

            ClientId = clientId;
            ClientSecret = clientSecret;
            RefreshToken = refreshToken;
            GrantType = "refresh_token";
        }

        /// <summary>
        /// The client ID you received from Pipedrive when you registered the application.
        /// </summary>
        [Parameter(Key = "client_id")]
        public string ClientId { get; private set; }

        /// <summary>
        /// The client secret you received from Pipedrive when you registered the application.
        /// </summary>
        [Parameter(Key = "client_secret")]
        public string ClientSecret { get; private set; }

        /// <summary>
        /// The refresh token you received from Pipedrive when requesting the <see cref="IOAuthClient.CreateAccessToken"> endpoint.
        /// </summary>
        [Parameter(Key = "refresh_token")]
        public string RefreshToken { get; private set; }

        /// <summary>
        /// The grant type for acquiring an refresh token.
        /// </summary>
        [Parameter(Key = "grant_type")]
        public string GrantType { get; private set; }

        internal string DebuggerDisplay
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "ClientId: {0}, ClientSecret: {1}, GrantType: {2}, RefreshToken: {3}",
                    ClientId,
                    ClientSecret,
                    GrantType,
                    RefreshToken);
            }
        }
    }
}
