using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pipedrive
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MarketingStatus
    {
        no_consent,
        unsubscribed,
        subscribed,
        archived
    }
}
