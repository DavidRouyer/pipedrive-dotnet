using Pipedrive.Clients;
using Pipedrive.Helpers;
using System;

namespace Pipedrive
{
    /// <summary>
    /// A Client for the Pipedrive API v1. You can read more about the api here: https://developers.pipedrive.com/docs/api/v1.
    /// </summary>
    public class PipedriveClient : IPipedriveClient
    {
        /// <summary>
        /// Create a new instance of the Pipedrive API v1 client pointing to the specified baseAddress.
        /// </summary>
        /// <param name="productInformation">
        /// The name (and optionally version) of the product using this library, the name of your Pipedrive organization. This is sent to the server as part of
        /// the user agent for analytics purposes, and used by Pipedrive to contact you if there are problems.
        /// </param>
        /// <param name="baseAddress">
        /// The address to point this client to.
        /// instances</param>
        public PipedriveClient(ProductHeaderValue productInformation, Uri baseAddress)
            : this(new Connection(productInformation, FixUpBaseUri(baseAddress)))
        {
        }

        /// <summary>
        /// Create a new instance of the Pipedrive API v1 client pointing to the specified baseAddress.
        /// </summary>
        /// <param name="productInformation">
        /// The name (and optionally version) of the product using this library, the name of your Pipedrive organization. This is sent to the server as part of
        /// the user agent for analytics purposes, and used by Pipedrive to contact you if there are problems.
        /// </param>
        /// <param name="baseAddress">
        /// The address to point this client to.
        /// instances</param>
        /// <param name="credentialStore">Provides credentials to the client when making requests</param>
        public PipedriveClient(ProductHeaderValue productInformation, Uri baseAddress, ICredentialStore credentialStore)
            : this(new Connection(productInformation, FixUpBaseUri(baseAddress), credentialStore))
        {
        }

        /// <summary>
        /// Create a new instance of the Pipedrive API v1 client using the specified connection.
        /// </summary>
        /// <param name="connection">The underlying <seealso cref="IConnection"/> used to make requests</param>
        public PipedriveClient(IConnection connection)
        {
            Ensure.ArgumentNotNull(connection, nameof(connection));

            Connection = connection;
            var apiConnection = new ApiConnection(connection);
            Activity = new ActivitiesClient(apiConnection);
            ActivityField = new ActivityFieldsClient(apiConnection);
            ActivityType = new ActivityTypesClient(apiConnection);
            Currency = new CurrenciesClient(apiConnection);
            Deal = new DealsClient(apiConnection);
            DealField = new DealFieldsClient(apiConnection);
            File = new FilesClient(apiConnection);
            Note = new NotesClient(apiConnection);
            OAuth = new OAuthClient(connection);
            Organization = new OrganizationsClient(apiConnection);
            OrganizationField = new OrganizationFieldsClient(apiConnection);
            Person = new PersonsClient(apiConnection);
            PersonField = new PersonFieldsClient(apiConnection);
            Pipeline = new PipelinesClient(apiConnection);
            Stage = new StagesClient(apiConnection);
            User = new UsersClient(apiConnection);
            Webhook = new WebhooksClient();
        }

        /// <summary>
        /// Set the Pipedrive API request timeout.
        /// Useful to set a specific timeout for lengthy operations, such as uploading release assets
        /// </summary>
        /// <remarks>
        /// See more information here: https://technet.microsoft.com/library/system.net.http.httpclient.timeout(v=vs.110).aspx
        /// </remarks>
        /// <param name="timeout">The Timeout value</param>
        public void SetRequestTimeout(TimeSpan timeout)
        {
            Connection.SetRequestTimeout(timeout);
        }

        /// <summary>
        /// Gets the latest API Info - this will be null if no API calls have been made
        /// </summary>
        /// <returns><seealso cref="ApiInfo"/> representing the information returned as part of an Api call</returns>
        public ApiInfo GetLastApiInfo()
        {
            return Connection.GetLastApiInfo();
        }

        /// <summary>
        /// Convenience property for getting and setting credentials.
        /// </summary>
        /// <remarks>
        /// You can use this property if you only have a single hard-coded credential. Otherwise, pass in an
        /// <see cref="ICredentialStore"/> to the constructor.
        /// Setting this property will change the <see cref="ICredentialStore"/> to use
        /// the default <see cref="InMemoryCredentialStore"/> with just these credentials.
        /// </remarks>
        public Credentials Credentials
        {
            get { return Connection.Credentials; }
            // Note this is for convenience. We probably shouldn't allow this to be mutable.
            set
            {
                Ensure.ArgumentNotNull(value, nameof(value));
                Connection.Credentials = value;
            }
        }

        /// <summary>
        /// The base address of the Pipedrive API.
        /// </summary>
        public Uri BaseAddress
        {
            get { return Connection.BaseAddress; }
        }

        /// <summary>
        /// Provides a client connection to make rest requests to HTTP endpoints.
        /// </summary>
        public IConnection Connection { get; private set; }

        /// <summary>
        /// Access Pipedrive's Activity API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/Activities
        /// </remarks>
        public IActivitiesClient Activity { get; private set; }

        /// <summary>
        /// Access Pipedrive's Activity Field API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/ActivityFields
        /// </remarks>
        public IActivityFieldsClient ActivityField { get; private set; }

        /// <summary>
        /// Access Pipedrive's Activity Type API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/ActivityTypes
        /// </remarks>
        public IActivityTypesClient ActivityType { get; private set; }

        /// <summary>
        /// Access Pipedrive's Currency API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/Currencies
        /// </remarks>
        public ICurrenciesClient Currency { get; private set; }

        /// <summary>
        /// Access Pipedrive's Deal API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/Deals
        /// </remarks>
        public IDealsClient Deal { get; private set; }

        /// <summary>
        /// Access Pipedrive's Deal Field API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/DealFields
        /// </remarks>
        public IDealFieldsClient DealField { get; private set; }

        /// <summary>
        /// Access Pipedrive's File API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/Files
        /// </remarks>
        public IFilesClient File { get; private set; }

        /// <summary>
        /// Access Pipedrive's Note API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/Notes
        /// </remarks>
        public INotesClient Note { get; private set; }

        /// <summary>
        /// Access Pipedrive's OAuth API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://pipedrive.readme.io/docs/marketplace-oauth-authorization
        /// </remarks>
        public IOAuthClient OAuth { get; private set; }

        /// <summary>
        /// Access Pipedrive's Organization API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/Organizations
        /// </remarks>
        public IOrganizationsClient Organization { get; private set; }

        /// <summary>
        /// Access Pipedrive's Organization Field API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/OrganizationFields
        /// </remarks>
        public IOrganizationFieldsClient OrganizationField { get; private set; }

        /// <summary>
        /// Access Pipedrive's Person API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/Persons
        /// </remarks>
        public IPersonsClient Person { get; private set; }

        /// <summary>
        /// Access Pipedrive's Person Field API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/PersonFields
        /// </remarks>
        public IPersonFieldsClient PersonField { get; private set; }

        /// <summary>
        /// Access Pipedrive's Pipeline API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/Pipelines
        /// </remarks>
        public IPipelinesClient Pipeline { get; private set; }

        /// <summary>
        /// Access Pipedrive's Stage API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/Stages
        /// </remarks>
        public IStagesClient Stage { get; private set; }

        /// <summary>
        /// Access Pipedrive's User API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/Users
        /// </remarks>
        public IUsersClient User { get; private set; }

        /// <summary>
        /// Access Pipedrive's Webhook API.
        /// </summary>
        /// <remarks>
        /// Refer to the API documentation for more information: https://developers.pipedrive.com/docs/api/v1/#!/Webhooks
        /// </remarks>
        public IWebhooksClient Webhook { get; private set; }

        static Uri FixUpBaseUri(Uri uri)
        {
            Ensure.ArgumentNotNull(uri, nameof(uri));

            if (!uri.Host.EndsWith(".pipedrive.com"))
            {
                throw new ArgumentException("Not a Pipedrive url");
            }

            return new Uri(uri, new Uri("/v1/", UriKind.Relative));
        }
    }
}
