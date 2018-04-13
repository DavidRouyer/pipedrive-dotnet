using System;
using System.Diagnostics;
using System.Net;

namespace Pipedrive
{
    /// <summary>
    /// Represents a HTTP 501 - Not implemented response returned from the API.
    /// </summary>
    public class NotImplementedException : ApiException
    {
        /// <summary>
        /// Constructs an instance of NotImplementedException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        public NotImplementedException(IResponse response) : this(response, null)
        {
        }

        /// <summary>
        /// Constructs an instance of NotImplementedException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        /// <param name="innerException">The inner exception</param>
        public NotImplementedException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
            Debug.Assert(response != null && response.StatusCode == HttpStatusCode.NotImplemented,
                "NotImplementedException created with wrong status code");
        }

        public override string Message
        {
            get { return ApiErrorMessageSafe ?? "Not implemented"; }
        }
    }
}
