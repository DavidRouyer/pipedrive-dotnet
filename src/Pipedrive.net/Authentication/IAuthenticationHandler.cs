namespace Pipedrive.Internal
{
    interface IAuthenticationHandler
    {
        void Authenticate(IRequest request, Credentials credentials);
    }
}
