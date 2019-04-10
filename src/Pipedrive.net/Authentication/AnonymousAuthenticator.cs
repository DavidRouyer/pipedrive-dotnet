namespace Pipedrive.Internal
{
    class AnonymousAuthenticator : IAuthenticationHandler
    {
        public void Authenticate(IRequest request, Credentials credentials)
        {
            // Do nothing. Retain your anonymity.
        }
    }
}
