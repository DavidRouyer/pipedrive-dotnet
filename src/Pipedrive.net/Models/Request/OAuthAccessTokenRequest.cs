using System;
using System.Diagnostics;
using System.Globalization;
using Pipedrive.Helpers;
using Pipedrive.Internal;

namespace Pipedrive
{
    /// <summary>
    /// Used to create an OAuth login request.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class OAuthAccessTokenRequest : RequestParameters
    {
        /// <summary>
        /// Creates an instance of the OAuth login request with the required parameter.
        /// </summary>
        /// <param name="clientId">The client Id you received from Pipedrive when you registered the application.</param>
        /// <param name="clientSecret">The client secret you received from Pipedrive when you registered the application.</param>
        /// <param name="code">The code you received as a response to making the OAuth login request</param>
        public OAuthAccessTokenRequest(string clientId, string clientSecret, string code, Uri redirectUri)
        {
            Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
            Ensure.ArgumentNotNullOrEmptyString(clientSecret, nameof(clientSecret));
            Ensure.ArgumentNotNullOrEmptyString(code, nameof(code));
            Ensure.ArgumentNotNullOrEmptyString(redirectUri?.ToString() ?? string.Empty, nameof(redirectUri));

            ClientId = clientId;
            ClientSecret = clientSecret;
            Code = code;
            RedirectUri = redirectUri;
            GrantType = "authorization_code";
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
        /// The grant type for acquiring an access token.
        /// </summary>
        [Parameter(Key = "grant_type")]
        public string GrantType { get; private set; }

        /// <summary>
        /// The code you received as a response to making the <see cref="IOAuthClient.CreateAccessToken">OAuth login
        /// request</see>.
        /// </summary>
        [Parameter(Key = "code")]
        public string Code { get; private set; }

        /// <summary>
        /// The URL in your app where users will be sent after authorization.
        /// </summary>
        /// <remarks>
        /// See the documentation about <see href="https://pipedrive.readme.io/docs/marketplace-oauth-authorization#section-step-3-callback-to-your-app">redirect urls
        /// </see> for more information.
        /// </remarks>
        [Parameter(Key = "redirect_uri")]
        public Uri RedirectUri { get; set; }

        internal string DebuggerDisplay
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "ClientId: {0}, ClientSecret: {1}, GrantType: {2}, Code: {3}, RedirectUri: {4}",
                    ClientId,
                    ClientSecret,
                    GrantType,
                    Code,
                    RedirectUri);
            }
        }
    }
}
