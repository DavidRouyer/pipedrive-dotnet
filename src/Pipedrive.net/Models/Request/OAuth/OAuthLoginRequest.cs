using System;
using System.Diagnostics;
using System.Globalization;
using Pipedrive.Helpers;
using Pipedrive.Internal;

namespace Pipedrive
{
    /// <summary>
    /// Used to initiate an OAuth2 authentication flow from 3rd party web sites.
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class OAuthLoginRequest : RequestParameters
    {
        /// <summary>
        /// Creates an instance of the OAuth login request with the required parameter.
        /// </summary>
        /// <param name="clientId">The client Id you received from Pipedrive when you registered the application.</param>
        public OAuthLoginRequest(string clientId)
        {
            Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));

            ClientId = clientId;
        }

        /// <summary>
        /// The client Id you received from Pipedrive when you registered the application.
        /// </summary>
        /// <param name="clientId">The client Id you received from Pipedrive when you registered the application.</param>
        [Parameter(Key = "client_id")]
        public string ClientId { get; private set; }

        /// <summary>
        /// The URL in your app where users will be sent after authorization.
        /// </summary>
        /// <remarks>
        /// See the documentation about <see href="https://pipedrive.readme.io/docs/marketplace-oauth-authorization#section-step-3-callback-to-your-app">redirect urls
        /// </see> for more information.
        /// </remarks>
        [Parameter(Key = "redirect_uri")]
        public Uri RedirectUri { get; set; }

        /// <summary>
        /// An unguessable random string. It is used to protect against cross-site request forgery attacks. In ASP.NET
        /// MVC this would correspond to an anti-forgery token.
        /// </summary>
        [Parameter(Key = "state")]
        public string State { get; set; }

        internal string DebuggerDisplay
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, "ClientId: {0}, RedirectUri: {1}",
                    ClientId,
                    RedirectUri);
            }
        }
    }
}
