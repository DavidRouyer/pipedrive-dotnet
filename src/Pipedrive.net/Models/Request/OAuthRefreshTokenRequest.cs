using Pipedrive.Helpers;
using Pipedrive.Internal;

namespace Pipedrive
{
    public class OAuthRefreshTokenRequest : RequestParameters
    {
        public OAuthRefreshTokenRequest(string clientId, string clientSecret, string refreshToken)
        {
            Ensure.ArgumentNotNullOrEmptyString(clientId, nameof(clientId));
            Ensure.ArgumentNotNullOrEmptyString(clientSecret, nameof(clientSecret));
            Ensure.ArgumentNotNullOrEmptyString(refreshToken, nameof(refreshToken));

            ClientId = clientId;
            ClientSecret = clientSecret;
            RefreshToken = refreshToken;
        }

        [Parameter(Key = "refresh_token")]
        public string RefreshToken { get; }

        [Parameter(Key = "grant_type")]
        public string GrantType => "refresh_token";

        [Parameter(Key = "client_id")]
        public string ClientId { get; }

        [Parameter(Key = "client_secret")]
        public string ClientSecret { get; }
    }
}
