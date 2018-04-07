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
        public PipedriveClient(ProductHeaderValue productInformation, Uri baseAddress, string apiToken)
            : this(new Connection(productInformation, FixUpBaseUri(baseAddress), apiToken))
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
