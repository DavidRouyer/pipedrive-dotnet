using System.Collections.Generic;
using Pipedrive.Helpers;

namespace Pipedrive
{
    public class FairUsageLimit
    {
        public FairUsageLimit(IDictionary<string, string> responseHeaders)
        {
            Ensure.ArgumentNotNull(responseHeaders, nameof(responseHeaders));

            var foundHeader = responseHeaders.TryGetValue("x-daily-requests-left", out var dailyRequestsAsString);
            if (foundHeader == false || dailyRequestsAsString == null) DailyRequestsLeft = null;

            DailyRequestsLeft = int.TryParse(dailyRequestsAsString, out var dailyRequestsLeft)
                                    ? dailyRequestsLeft
                                    : null as int?;
        }

        public FairUsageLimit(int? dailyRequestsLeft)
        {
            DailyRequestsLeft = dailyRequestsLeft;
        }

        /// <summary>
        /// The number of POST/PUT requests remaining in the ongoing day (calculated in UTC)
        /// </summary>
        public int? DailyRequestsLeft { get; private set; }

        /// <summary>
        /// Allows you to clone FairUsageLimit
        /// </summary>
        /// <returns>A clone of <seealso cref="FairUsageLimit"/></returns>
        public FairUsageLimit Clone()
        {
            return new FairUsageLimit(DailyRequestsLeft);
        }
    }
}
