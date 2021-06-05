using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Pipedrive
{
    public class NewProductField
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("field_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FieldType FieldType { get; set; }

        [JsonProperty("options")]
        public string Options { get; set; }

        public NewProductField(string name, FieldType fieldType)
        {
            this.Name = name;
            this.FieldType = fieldType;
        }
    }
}
