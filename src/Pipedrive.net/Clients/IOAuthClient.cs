﻿using System;
using System.Threading.Tasks;

namespace Pipedrive.Clients
{
    /// <summary>
    /// Provides methods used in the OAuth web flow.
    /// </summary>
    public interface IOAuthClient
    {
        /// <summary>
        /// Gets the URL used in the first step of the web flow. The Web application should redirect to this URL.
        /// </summary>
        /// <param name="request">Parameters to the OAuth web flow login url</param>
        /// <returns></returns>
        Uri GetPipedriveLoginUrl(OAuthLoginRequest request);

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
        Task<OAuthToken> CreateAccessToken(OAuthAccessTokenRequest request);

        /// <summary>
        /// Makes a request to refresh an access token using the access token previously created
        /// <see cref="GetPipedriveLoginUrl">GitHub login url</see> to the application.
        /// </summary>
        /// <remarks>
        /// If the user accepts your request, Pipedrive redirects back to your site with a temporary code in a code
        /// parameter as well as the state you provided in the previous step in a state parameter. If the states don’t
        /// match, the request has been created by a third party and the process should be aborted. Exchange this for
        /// an access token using this method.
        /// </remarks>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<OAuthToken> RefreshAccessToken(OAuthRefreshTokenRequest request);

        Task RevokeToken(OAuthRevokeTokenRequest request);
    }
}
