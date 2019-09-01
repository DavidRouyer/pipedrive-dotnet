using System.Collections.Generic;

namespace Pipedrive
{
    public interface IEntityWithCustomFields
    {
        IDictionary<string, ICustomField> CustomFields { get; set; }
    }
}
