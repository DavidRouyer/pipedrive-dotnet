using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class Lead : AbstractLead, IEntityWithCustomFields
    {
        public string Note { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; }
    }
}
