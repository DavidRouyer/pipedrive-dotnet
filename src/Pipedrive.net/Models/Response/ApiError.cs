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

        public ApiError(string error)
        {
            Error = error;
        }

        public string Succes { get; set; }

        /// <summary>
        /// The error message
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// Additional details about the error
        /// </summary>
        [JsonProperty("error_info")]
        public string ErrorInfo { get; set; }

        public string Data { get; set; }

        [JsonProperty("additional_data")]
        public string AdditionalData { get; set; }
    }
}