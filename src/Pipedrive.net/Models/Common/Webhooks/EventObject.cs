using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pipedrive.Models.Common.Webhooks
{

    [JsonConverter(typeof(StringEnumConverter))]
    public enum EventObject
    {
        [EnumMember(Value = "activity")] Activity,
        [EnumMember(Value = "activityType")] ActivityType,
        [EnumMember(Value = "deal")] Deal,
        [EnumMember(Value = "note")] Note,
        [EnumMember(Value = "organization")] Organization,
        [EnumMember(Value = "person")] Person,
        [EnumMember(Value = "pipeline")] Pipeline,
        [EnumMember(Value = "product")] Product,
        [EnumMember(Value = "stage")] Stage,
        [EnumMember(Value = "user")] User,
        [EnumMember(Value = "*")] All,
    }
}
