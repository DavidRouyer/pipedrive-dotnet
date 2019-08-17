using System;
using System.Collections.Generic;
using Pipedrive.Helpers;
using Pipedrive.Internal;

namespace Pipedrive
{
    class ApiTokenAuthenticator : IAuthenticationHandler
    {
        public void Authenticate(IRequest request, Credentials credentials)
        {
            Ensure.ArgumentNotNull(request, nameof(request));
            Ensure.ArgumentNotNull(credentials, nameof(credentials));
            Ensure.ArgumentNotNull(credentials.Password, nameof(credentials.Password));

            if (credentials.Login != null)
            {
                throw new InvalidOperationException("The Login is not null for a token authentication request. You " +
                                                    "probably did something wrong.");
            }

            ((Request)request).Endpoint = request.Endpoint.ApplyParameters(
                new Dictionary<string, string> { { "api_token", credentials.Password } });
        }
    }
}
