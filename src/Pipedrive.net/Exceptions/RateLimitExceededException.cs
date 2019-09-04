using System;
using Pipedrive.Helpers;

namespace Pipedrive
{
    /// <summary>
    /// Exception thrown when Pipedrive API Rate limits are exceeded.
    /// </summary>
    /// <summary>
    /// <para>
    /// For requests using your API token, the API allows to perform 100 requests per 10 seconds.
    /// </para>
    /// <para>See https://developers.pipedrive.com/docs/api/v1/#/ for more details.</para>
    /// </summary>
    public class RateLimitExceededException : ForbiddenException
    {
        readonly RateLimit _rateLimit;

        /// <summary>
        /// Constructs an instance of RateLimitExceededException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        public RateLimitExceededException(IResponse response) : this(response, null)
        {
        }

        /// <summary>
        /// Constructs an instance of RateLimitExceededException
        /// </summary>
        /// <param name="response">The HTTP payload from the server</param>
        /// <param name="innerException">The inner exception</param>
        public RateLimitExceededException(IResponse response, Exception innerException) : base(response, innerException)
        {
            Ensure.ArgumentNotNull(response, nameof(response));

            _rateLimit = response.ApiInfo.RateLimit;
        }

        /// <summary>
        /// The maximum number of requests that the consumer is permitted to make per hour.
        /// </summary>
        public int Limit
        {
            get { return _rateLimit.Limit; }
        }

        /// <summary>
        /// The number of requests remaining in the current rate limit window.
        /// </summary>
        public int Remaining
        {
            get { return _rateLimit.Remaining; }
        }

        /// <summary>
        /// The date and time at which the current rate limit window resets
        /// </summary>
        public DateTimeOffset Reset
        {
            get { return _rateLimit.Reset; }
        }

        // TODO: Might be nice to have this provide a more detailed message such as what the limit is,
        // how many are remaining, and when it will reset. I'm too lazy to do it now.
        public override string Message
        {
            get { return ApiErrorMessageSafe ?? "API Rate Limit exceeded"; }
        }
    }
}
