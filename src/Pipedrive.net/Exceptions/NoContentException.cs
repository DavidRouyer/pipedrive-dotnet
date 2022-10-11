using System;
using System.Diagnostics;
using System.Net;

namespace Pipedrive
{
    /// <summary>
    /// Represents a HTTP 204 - No content response returned from the API.
    /// </summary>
    public class NoContentException : ApiException
    {
        /// <summary>
        /// Constructs an instance of NoContentException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        public NoContentException(IResponse response) : this(response, null)
        {
        }

        /// <summary>
        /// Constructs an instance of NoContentException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        /// <param name="innerException">The inner exception</param>
        public NoContentException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.NoContent,
                "NoContentException created with wrong status code");
        }

        public override string Message
        {
            get { return ApiErrorMessageSafe ?? "No content"; }
        }
    }
}
