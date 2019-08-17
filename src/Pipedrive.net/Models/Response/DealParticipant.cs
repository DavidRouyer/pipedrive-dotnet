using System;
using Newtonsoft.Json;

namespace Pipedrive.Models.Response
{
    public class DealParticipant
    {
        public long Id { get; set; }

        [JsonProperty("person_id")]
        public AssociatedPerson PersonId { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("added_by_user_id")]
        public AssociatedUser AddedByUserId { get; set; }

        [JsonProperty("person")]
        public Person Person { get; set; }

        [JsonProperty("related_item_data")]
        public DealParticipantRelatedItemData RelatedItemData { get; set; }

        [JsonProperty("related_item_type")]
        public string RelatedItemType { get; set; }

        [JsonProperty("related_item_id")]
        public long RelatedItemId { get; set; }
    }

    public class DealParticipantRelatedItemData
    {
        [JsonProperty("deal_id")]
        public long DealId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
