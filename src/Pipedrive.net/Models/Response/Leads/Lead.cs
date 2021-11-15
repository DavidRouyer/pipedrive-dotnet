using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class Lead : AbstractLead, IEntityWithCustomFields
    {
        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; }

        public LeadUpdate ToUpdate()
        {
            return new LeadUpdate
            {
                Title = Title,
                Value = Value.Amount,
                PersonId = PersonId,
                OrganizationId = OrganizationId,
                ExpectedCloseDate = ExpectedCloseDate,
                CustomFields = CustomFields,
                LabelIds = LabelIds,
                OwnerId = OwnerId,
                WasSeen = WasSeen
            };
        }
    }
}
