using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.CustomFields;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class Organization : AbstractOrganization<UserCustomField, Picture>, IEntityWithCustomFields
    {
        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; }

        public OrganizationUpdate ToUpdate()
        {
            return new OrganizationUpdate
            {
                Name = Name,
                OwnerId = OwnerId?.Value,
                VisibleTo = VisibleTo,
                CustomFields = CustomFields
            };
        }
    }
}
