using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class WebhookPerson : AbstractPerson<long?, long?>, IEntityWithCustomFields
    {
        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; }

        public PersonUpdate ToUpdate()
        {
            return new PersonUpdate
            {
                Name = Name,
                Email = Email,
                Phone = Phone,
                OrgId = OrgId,
                OwnerId = OwnerId,
                VisibleTo = VisibleTo,
                CustomFields = CustomFields
            };
        }
    }
}
