using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class PersonUpdate : IEntityWithCustomFields
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("owner_id")]
        public long? OwnerId { get; set; }

        [JsonProperty("org_id")]
        public long? OrgId { get; set; }

        [JsonProperty("email")]
        public List<Email> Email { get; set; }

        [JsonProperty("phone")]
        public List<Phone> Phone { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        [JsonProperty("marketing_status")]
        public MarketingStatus? MarketingStatus { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; }
    }
}
