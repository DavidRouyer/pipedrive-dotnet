using Newtonsoft.Json;
using Pipedrive.CustomFields;
using Pipedrive.Internal;
using System;
using System.Collections.Generic;

namespace Pipedrive
{
    [JsonConverter(typeof(CustomFieldConverter))]
    public class Person : IEntityWithCustomFields
    {
        public long Id { get; set; }

        [JsonProperty("company_id")]
        public long CompanyId { get; set; }

        [JsonProperty("owner_id")]
        public UserCustomField OwnerId { get; set; }

        [JsonProperty("org_id")]
        public OrganizationCustomField OrgId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("open_deals_count")]
        public int OpenDealsCount { get; set; }

        [JsonProperty("related_open_deals_count")]
        public int RelatedOpenDealsCount { get; set; }

        [JsonProperty("closed_deals_count")]
        public int ClosedDealsCount { get; set; }

        [JsonProperty("related_closed_deals_count")]
        public int RelatedClosedDealsCount { get; set; }

        [JsonProperty("participant_open_deals_count")]
        public int ParticipantOpenDealsCount { get; set; }

        [JsonProperty("participant_closed_deals_count")]
        public int ParticipantClosedDealsCount { get; set; }

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

        [JsonProperty("files_count")]
        public int FilesCount { get; set; }

        [JsonProperty("notes_count")]
        public int NotesCount { get; set; }

        [JsonProperty("followers_count")]
        public int FollowersCount { get; set; }

        [JsonProperty("won_deals_count")]
        public int WonDealsCount { get; set; }

        [JsonProperty("related_won_deals_count")]
        public int RelatedWonDealsCount { get; set; }

        [JsonProperty("lost_deals_count")]
        public int LostDealsCount { get; set; }

        [JsonProperty("related_lost_deals_count")]
        public int RelatedLostDealsCount { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("phone")]
        public List<Phone> Phone { get; set; }

        [JsonProperty("email")]
        public List<Email> Email { get; set; }

        [JsonProperty("first_char")]
        public char FirstChar { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("visible_to")]
        public Visibility VisibleTo { get; set; }

        [JsonProperty("picture_id")]
        public Picture PictureId { get; set; }

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

        [JsonProperty("timeline_last_activity_time")]
        public string TimelineLastActivityTime { get; set; }

        [JsonProperty("timeline_last_activity_time_by_owner")]
        public string TimelineLastActivityTimeByOwner { get; set; }

        [JsonProperty("last_incoming_mail_time")]
        public DateTime? LastIncomingMailTime { get; set; }

        [JsonProperty("last_outgoing_mail_time")]
        public DateTime? LastOutgoingMailTime { get; set; }

        [JsonProperty("org_name")]
        public string OrgName { get; set; }

        [JsonProperty("owner_name")]
        public string OwnerName { get; set; }

        [JsonProperty("cc_email")]
        public string CcEmail { get; set; }

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
