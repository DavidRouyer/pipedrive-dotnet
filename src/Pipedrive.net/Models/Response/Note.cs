using Newtonsoft.Json;
using System;

namespace Pipedrive
{
    public class Note
    {
        public long Id { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("deal_id")]
        public long? DealId { get; set; }

        [JsonProperty("person_id")]
        public long? PersonId { get; set; }

        [JsonProperty("org_id")]
        public long? OrgId { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("pinned_to_deal_flag")]
        public bool PinnedToDealFlag { get; set; }

        [JsonProperty("pinned_to_person_flag")]
        public bool PinnedToPersonFlag { get; set; }

        [JsonProperty("pinned_to_organization_flag")]
        public bool PinnedToOrganizationFlag { get; set; }

        [JsonProperty("last_update_user_id")]
        public long? LastUpdateUserId { get; set; }

        [JsonProperty("organization")]
        public object Organization { get; set; }

        [JsonProperty("person")]
        public object Person { get; set; }

        [JsonProperty("deal")]
        public object Deal { get; set; }

        [JsonProperty("user")]
        public object User { get; set; }

        public NoteUpdate ToUpdate()
        {
            return new NoteUpdate
            {
                Content = Content,
                DealId = DealId,
                PersonId = PersonId,
                OrgId = OrgId,
                PinnedToDealFlag = PinnedToDealFlag,
                PinnedToOrganizationFlag = PinnedToOrganizationFlag,
                PinnedToPersonFlag = PinnedToPersonFlag
            };
        }
    }
}
