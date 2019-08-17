using Pipedrive.Helpers;

namespace Pipedrive
{
    public class Credentials
    {
        public static readonly Credentials Anonymous = new Credentials();

        private Credentials()
        {
            AuthenticationType = AuthenticationType.Anonymous;
        }

        public Credentials(string token) : this(token, AuthenticationType.ApiToken) { }

        public Credentials(string token, AuthenticationType authenticationType)
        {
            Ensure.ArgumentNotNullOrEmptyString(token, nameof(token));

            Login = null;
            Password = token;
            AuthenticationType = authenticationType;
        }

        public Credentials(string login, string password, AuthenticationType authenticationType)
        {
            Ensure.ArgumentNotNullOrEmptyString(login, nameof(login));
            Ensure.ArgumentNotNullOrEmptyString(password, nameof(password));

            Login = login;
            Password = password;
            AuthenticationType = authenticationType;
        }

        public string Login
        {
            get;
            private set;
        }

        public string Password
        {
            get;
            private set;
        }

        public AuthenticationType AuthenticationType
        {
            get;
            private set;
        }
    }
}
