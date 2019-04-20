using Pipedrive.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Pipedrive.Internal
{
    public class ReadOnlyPagedCollection<T> : ReadOnlyCollection<T>, IReadOnlyPagedCollection<T>
    {
        readonly ApiInfo _info;
        readonly Func<Uri, Task<IApiResponse<JsonResponse<List<T>>>>> _nextPageFunc;

        public ReadOnlyPagedCollection(IApiResponse<JsonResponse<List<T>>> response, Func<Uri, Task<IApiResponse<JsonResponse<List<T>>>>> nextPageFunc)
            : base(response != null ? response.Body?.Data ?? new List<T>() : new List<T>())
        {
            Ensure.ArgumentNotNull(response, nameof(response));
            Ensure.ArgumentNotNull(nextPageFunc, nameof(nextPageFunc));

            _nextPageFunc = nextPageFunc;
            if (response != null)
            {
                _info = response.HttpResponse.ApiInfo;
            }
        }

        public async Task<IReadOnlyPagedCollection<T>> GetNextPage()
        {
            var nextPageUrl = _info.GetNextPageUrl();
            if (nextPageUrl == null) return null;

            var maybeTask = _nextPageFunc(nextPageUrl);

            if (maybeTask == null)
            {
                return null;
            }

            var response = await maybeTask.ConfigureAwait(false);
            return new ReadOnlyPagedCollection<T>(response, _nextPageFunc);
        }
    }
}
