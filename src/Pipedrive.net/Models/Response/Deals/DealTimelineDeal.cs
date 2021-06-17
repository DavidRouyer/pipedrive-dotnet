using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class DealTimelineDeal : AbstractDeal<long?, long?, long?>, IEntityWithCustomFields
    {
        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; }
    }
}
