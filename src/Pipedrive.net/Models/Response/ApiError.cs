using Newtonsoft.Json;
using System.Collections.Generic;

namespace Pipedrive
{
    /// <summary>
    /// Error payload from the API reposnse
    /// </summary>
    public class ApiError
    {
        public ApiError() { }

        public ApiError(string message)
        {
            Message = message;
        }

        /// <summary>
        /// The error message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// URL to the documentation for this error.
        /// </summary>
        [JsonProperty("documentation_url")]
        public string DocumentationUrl { get; set; }

        /// <summary>
        /// Additional details about the error
        /// </summary>
        public IReadOnlyList<ApiErrorDetail> Errors { get; set; }
    }
}