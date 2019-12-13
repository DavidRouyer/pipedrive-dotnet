using System;
using System.Collections.Generic;
using Pipedrive.Helpers;
using Pipedrive.Internal;

namespace Pipedrive
{
    public class RateLimit
    {
        public RateLimit()
        {
        }

        public RateLimit(IDictionary<string, string> responseHeaders)
        {
            Ensure.ArgumentNotNull(responseHeaders, nameof(responseHeaders));

            Limit = (int)GetHeaderValueAsInt32Safe(responseHeaders, "X-RateLimit-Limit");
            Remaining = (int)GetHeaderValueAsInt32Safe(responseHeaders, "X-RateLimit-Remaining");
            ResetInSeconds = GetHeaderValueAsInt32Safe(responseHeaders, "X-RateLimit-Reset");
        }

        public RateLimit(int limit, int remaining, long reset)
        {
            Ensure.ArgumentNotNull(limit, nameof(limit));
            Ensure.ArgumentNotNull(remaining, nameof(remaining));
            Ensure.ArgumentNotNull(reset, nameof(reset));

            Limit = limit;
            Remaining = remaining;
            ResetInSeconds = reset;
        }

        /// <summary>
        /// The maximum number of requests that the consumer is permitted to make per hour.
        /// </summary>
        public int Limit { get; private set; }

        /// <summary>
        /// The number of requests remaining in the current rate limit window.
        /// </summary>
        public int Remaining { get; private set; }

        /// <summary>
        /// The date and time at which the current rate limit window resets
        /// </summary>
        [Parameter(Key = "ignoreThisField")]
        public DateTimeOffset Reset => new DateTimeOffset(DateTime.UtcNow.CeilingSecond().AddSeconds(ResetInSeconds));

        /// <summary>
        /// The date and time at which the current rate limit window resets - in UTC epoch seconds
        /// </summary>
        [Parameter(Key = "reset")]
        public long ResetInSeconds { get; private set; }

        static long GetHeaderValueAsInt32Safe(IDictionary<string, string> responseHeaders, string key)
        {
            string value;
            long result;
            return !responseHeaders.TryGetValue(key, out value) || value == null || !long.TryParse(value, out result)
                ? 0
                : result;
        }

        /// <summary>
        /// Allows you to clone RateLimit
        /// </summary>
        /// <returns>A clone of <seealso cref="RateLimit"/></returns>
        public RateLimit Clone()
        {
            return new RateLimit
            {
                Limit = Limit,
                Remaining = Remaining,
                ResetInSeconds = ResetInSeconds
            };
        }
    }
}
