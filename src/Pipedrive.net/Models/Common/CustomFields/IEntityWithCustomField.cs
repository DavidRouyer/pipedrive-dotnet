using System.Collections.Generic;

namespace Pipedrive
{
    public interface IEntityWithCustomFields
    {
        IDictionary<string, IField> CustomFields { get; set; }
    }
}
