using Newtonsoft.Json;

namespace Pipedrive
{
    public class NewNote
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("deal_id")]
        public long? DealId { get; set; }

        [JsonProperty("person_id")]
        public long? PersonId { get; set; }

        [JsonProperty("org_id")]
        public long? OrgId { get; set; }

        [JsonProperty("pinned_to_deal_flag")]
        public bool PinnedToDealFlag { get; set; }

        [JsonProperty("pinned_to_organization_flag")]
        public bool PinnedToOrganizationFlag { get; set; }

        [JsonProperty("pinned_to_person_flag")]
        public bool PinnedToPersonFlag { get; set; }

        public NewNote(string content)
        {
            Content = content;
        }
    }
}
