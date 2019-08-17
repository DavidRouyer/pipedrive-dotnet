using Newtonsoft.Json;
using Pipedrive.Internal;
using System;
using System.Collections.Generic;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class WebhookDeal : IEntityWithCustomFields
    {
        public long Id { get; set; }

        [JsonProperty("creator_user_id")]
        public long? CreatorUserId { get; set; }

        [JsonProperty("user_id")]
        public long? UserId { get; set; }

        [JsonProperty("person_id")]
        public long? PersonId { get; set; }

        [JsonProperty("org_id")]
        public long? OrgId { get; set; }

        [JsonProperty("stage_id")]
        public long StageId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("value")]
        public decimal Value { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }

        [JsonProperty("stage_change_time")]
        public DateTime? StageChangeTime { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("status")]
        public DealStatus Status { get; set; }

        [JsonProperty("probability")]
        public double? Probability { get; set; }

        [JsonProperty("next_activity_date")]
        public string NextActivityDate { get; set; }

        [JsonProperty("next_activity_time")]
        public string NextActivityTime { get; set; }

        [JsonProperty("next_activity_id")]
        public long? NextActivityId { get; set; }

        [JsonProperty("last_activity_id")]
        public long? LastActivityId { get; set; }

        [JsonProperty("last_activity_date")]
        public string LastActivityDate { get; set; }

        [JsonProperty("lost_reason")]
        public string LostReason { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        [JsonProperty("close_time")]
        public DateTime? CloseTime { get; set; }

        [JsonProperty("pipeline_id")]
        public long PipelineId { get; set; }

        [JsonProperty("won_time")]
        public DateTime? WonTime { get; set; }

        [JsonProperty("first_won_time")]
        public DateTime? FirstWonTime { get; set; }

        [JsonProperty("lost_time")]
        public DateTime? LostTime { get; set; }

        [JsonProperty("products_count")]
        public int ProductsCount { get; set; }

        [JsonProperty("files_count")]
        public int FilesCount { get; set; }

        [JsonProperty("notes_count")]
        public int NotesCount { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("email_messages_count")]
        public int EmailMessagesCount { get; set; }

        [JsonProperty("activities_count")]
        public int ActivitiesCount { get; set; }

        [JsonProperty("done_activities_count")]
        public int DoneActivitiesCount { get; set; }

        [JsonProperty("undone_activities_count")]
        public int UndoneActivitiesCount { get; set; }

        [JsonProperty("reference_activities_count")]
        public int ReferenceActivitiesCount { get; set; }

        [JsonProperty("participants_count")]
        public int ParticipantsCount { get; set; }

        [JsonProperty("expected_close_date")]
        public DateTime? ExpectedCloseDate { get; set; }

        [JsonProperty("last_incoming_mail_time")]
        public DateTime? LastIncomingMailTime { get; set; }

        [JsonProperty("last_outgoing_mail_time")]
        public DateTime? LastOutgoingMailTime { get; set; }

        [JsonProperty("stage_order_nr")]
        public int StageOrderNr { get; set; }

        [JsonProperty("person_name")]
        public string PersonName { get; set; }

        [JsonProperty("org_name")]
        public string OrgName { get; set; }

        [JsonProperty("next_activity_subject")]
        public string NextActivitySubject { get; set; }

        [JsonProperty("next_activity_type")]
        public string NextActivityType { get; set; }

        [JsonProperty("next_activity_duration")]
        public string NextActivityDuration { get; set; }

        [JsonProperty("next_activity_note")]
        public string NextActivityNote { get; set; }

        [JsonProperty("formatted_value")]
        public string FormattedValue { get; set; }

        [JsonProperty("rotten_time")]
        public string RottenTime { get; set; }

        [JsonProperty("weighted_value")]
        public int WeightedValue { get; set; }

        [JsonProperty("formatted_weighted_value")]
        public string FormattedWeightedValue { get; set; }

        [JsonProperty("owner_name")]
        public string OwnerName { get; set; }

        [JsonProperty("cc_email")]
        public string CcEmail { get; set; }

        [JsonProperty("org_hidden")]
        public bool OrgHidden { get; set; }

        [JsonProperty("person_hidden")]
        public bool PersonHidden { get; set; }

        [JsonIgnore]
        public IDictionary<string, ICustomField> CustomFields { get; set; }

        public DealUpdate ToUpdate()
        {
            return new DealUpdate
            {
                Title = Title,
                Value = Value,
                Currency = Currency,
                UserId = UserId,
                PersonId = PersonId,
                OrgId = OrgId,
                StageId = StageId,
                Status = Status,
                Probability = Probability,
                LostReason = LostReason,
                AddTime = AddTime,
                VisibleTo = VisibleTo,
                CustomFields = CustomFields
            };
        }
    }
}
