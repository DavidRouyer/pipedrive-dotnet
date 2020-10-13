using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Pipedrive.CustomFields;
using Pipedrive.Internal;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class Person : AbstractPerson<UserCustomField, OrganizationCustomField>, IEntityWithCustomFields
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
                OrgId = OrgId?.Value,
                OwnerId = OwnerId?.Value,
                VisibleTo = VisibleTo,
                CustomFields = CustomFields
            };
        }
    }
}
