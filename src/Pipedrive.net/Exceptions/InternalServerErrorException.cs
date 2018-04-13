using System;
using System.Diagnostics;
using System.Net;

namespace Pipedrive
{
    /// <summary>
    /// Represents a HTTP 500 - Internal server error response returned from the API.
    /// </summary>
    public class InternalServerErrorException : ApiException
    {
        /// <summary>
        /// Constructs an instance of InternalServerErrorException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        public InternalServerErrorException(IResponse response) : this(response, null)
        {
        }

        /// <summary>
        /// Constructs an instance of InternalServerErrorException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        /// <param name="innerException">The inner exception</param>
        public InternalServerErrorException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.InternalServerError,
                "InternalServerErrorException created with wrong status code");
        }

        public override string Message
        {
            get { return ApiErrorMessageSafe ?? "Internal server error"; }
        }
    }
}
