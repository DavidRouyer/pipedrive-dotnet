using Pipedrive.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pipedrive
{
    /// <summary>
    /// Extra information returned as part of each api response.
    /// </summary>
    public class ApiInfo
    {
        public ApiInfo(IDictionary<string, Uri> links,
            string etag,
            RateLimit rateLimit)
        {
            Ensure.ArgumentNotNull(links, nameof(links));

            Links = new ReadOnlyDictionary<string, Uri>(links);
            Etag = etag;
            RateLimit = rateLimit;
        }

        /// <summary>
        /// Etag
        /// </summary>
        public string Etag { get; private set; }

        /// <summary>
        /// Links to things like next/previous pages
        /// </summary>
        public IReadOnlyDictionary<string, Uri> Links { get; private set; }

        /// <summary>
        /// Information about the API rate limit
        /// </summary>
        public RateLimit RateLimit { get; private set; }

        /// <summary>
        /// Allows you to clone ApiInfo 
        /// </summary>
        /// <returns>A clone of <seealso cref="ApiInfo"/></returns>
        public ApiInfo Clone()
        {
            return new ApiInfo(Links.Clone(),
                               Etag != null ? new string(Etag.ToCharArray()) : null,
                               RateLimit != null ? RateLimit.Clone() : null);
        }
    }
}
