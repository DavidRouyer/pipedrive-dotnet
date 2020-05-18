using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewFile
    {
        [JsonProperty("file")]
        public RawFile File { get; set; }

        [JsonProperty("deal_id")]
        public long? DealId { get; set; }

        [JsonProperty("person_id")]
        public long? PersonId { get; set; }

        [JsonProperty("org_id")]
        public long? OrgId { get; set; }

        [JsonProperty("product_id")]
        public long? ProductId { get; set; }

        [JsonProperty("activity_id")]
        public long? ActivityId { get; set; }

        [JsonProperty("note_id")]
        public long? NoteId { get; set; }

        public NewFile(RawFile file)
        {
            this.File = file;
        }
    }
}
