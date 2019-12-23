using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pipedrive.Models.Common.Webhooks
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventAction
    {
        [EnumMember(Value = "added")]
        Added,
        [EnumMember(Value = "updated")]
        Updated,
        [EnumMember(Value = "merged")]
        Merged,
        [EnumMember(Value = "deleted")]
        Deleted,
        [EnumMember(Value = "*")]
        All,
    }
}
