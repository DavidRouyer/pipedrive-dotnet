using System;
using System.Diagnostics;
using System.Net;

namespace Pipedrive
{
    /// <summary>
    /// Represents a HTTP 429 - Too many requests response returned from the API.
    /// </summary>
    public class TooManyRequestsException : ApiException
    {
        /// <summary>
        /// Constructs an instance of TooManyRequestsException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        public TooManyRequestsException(IResponse response) : this(response, null)
        {
        }

        /// <summary>
        /// Constructs an instance of TooManyRequestsException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        /// <param name="innerException">The inner exception</param>
        public TooManyRequestsException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == (HttpStatusCode)429,
                "TooManyRequestsException created with wrong status code");
        }

        public override string Message
        {
            get { return ApiErrorMessageSafe ?? "Too many requests"; }
        }
    }
}
