using Pipedrive.Helpers;
using Pipedrive.Internal;

namespace Pipedrive
{
    public class OAuthRevokeTokenRequest : RequestParameters
    {
        /// <summary>
        /// Request to revoke a token in Pipedrive
        /// </summary>
        /// <param name="clientId">Client Id</param>
        /// <param name="clientSecret">Client Secret</param>
        /// <param name="token">The token to be revoked</param>
        /// <param name="tokenTypeHint">Either access_token or refresh_token</param>
        public OAuthRevokeTokenRequest(string clientId, string clientSecret, string token, string tokenTypeHint)
        {
            Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
            Ensure.ArgumentNotNullOrEmptyString(clientSecret, nameof(clientSecret));
            Ensure.ArgumentNotNullOrEmptyString(token, nameof(token));
            Ensure.ArgumentNotNullOrEmptyString(tokenTypeHint, nameof(tokenTypeHint));

            ClientId = clientId;
            ClientSecret = clientSecret;
            Token = token;
            TokenTypeHint = tokenTypeHint;
        }

        [Parameter(Key = "token")]
        public string Token { get; }

        [Parameter(Key = "token_type_hint")]
        public string TokenTypeHint { get; set; }

        [Parameter(Key = "client_id")]
        public string ClientId { get; }

        [Parameter(Key = "client_secret")]
        public string ClientSecret { get; }
    }
}
