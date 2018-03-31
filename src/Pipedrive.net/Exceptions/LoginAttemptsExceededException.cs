using System;
using System.Diagnostics.CodeAnalysis;

namespace Pipedrive
{
    /// <summary>
    /// Represents a "Login Attempts Exceeded" response returned from the API.
    /// </summary>
    public class LoginAttemptsExceededException : ForbiddenException
    {
        /// <summary>
        /// Constructs an instance of LoginAttemptsExceededException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        public LoginAttemptsExceededException(IResponse response)
            : base(response)
        {
        }

        /// <summary>
        /// Constructs an instance of LoginAttemptsExceededException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        /// <param name="innerException">The inner exception</param>
        public LoginAttemptsExceededException(IResponse response, Exception innerException)
            : base(response, innerException)
        {
        }

        public override string Message
        {
            get { return ApiErrorMessageSafe ?? "Maximum number of login attempts exceeded"; }
        }
    }
}
