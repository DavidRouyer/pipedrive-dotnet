﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Pipedrive.Helpers;

namespace Pipedrive.Internal
{
    internal static class ApiInfoParser
    {
        const RegexOptions regexOptions =
             RegexOptions.Compiled |
             RegexOptions.IgnoreCase;

        static readonly Regex _linkRelRegex = new Regex("rel=\"(next|prev|first|last)\"", regexOptions);
        static readonly Regex _linkUriRegex = new Regex("<(.+)>", regexOptions);

        public static ApiInfo ParseResponseHeaders(IDictionary<string, string> responseHeaders)
        {
            Ensure.ArgumentNotNull(responseHeaders, nameof(responseHeaders));

            var httpLinks = new Dictionary<string, Uri>();
            string etag = null;

            if (responseHeaders.ContainsKey("ETag"))
            {
                etag = responseHeaders["ETag"];
            }

            if (responseHeaders.ContainsKey("Link"))
            {
                var links = responseHeaders["Link"].Split(',');
                foreach (var link in links)
                {
                    var relMatch = _linkRelRegex.Match(link);
                    if (!relMatch.Success || relMatch.Groups.Count != 2) break;

                    var uriMatch = _linkUriRegex.Match(link);
                    if (!uriMatch.Success || uriMatch.Groups.Count != 2) break;

                    httpLinks.Add(relMatch.Groups[1].Value, new Uri(uriMatch.Groups[1].Value));
                }
            }

            return new ApiInfo(httpLinks, etag, new RateLimit(responseHeaders));
        }
    }
}
