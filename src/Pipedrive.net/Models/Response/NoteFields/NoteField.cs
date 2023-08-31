using Newtonsoft.Json;

namespace Pipedrive
{
    public class NoteField
    {
        public long Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        [JsonProperty("field_type")]
        public string FieldType { get; set; }

        [JsonProperty("active_flag")]
        public bool? ActiveFlag { get; set; }

        [JsonProperty("edit_flag")]
        public bool? EditFlag { get; set; }

        [JsonProperty("bulk_edit_allowed")]
        public bool? BulkEditAllowed { get; set; }

        [JsonProperty("mandatory_flag")]
        public bool? MantatoryFlag { get; set; }
    }
}
