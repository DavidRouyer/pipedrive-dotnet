using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Pipedrive
{
    public abstract class AbstractPerson<TUser, TOrganization>
    {
        public long Id { get; set; }

        [JsonProperty("company_id")]
        public long CompanyId { get; set; }

        [JsonProperty("owner_id")]
        public TUser OwnerId { get; set; }

        [JsonProperty("org_id")]
        public TOrganization OrgId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("open_deals_count")]
        public long OpenDealsCount { get; set; }

        [JsonProperty("related_open_deals_count")]
        public long RelatedOpenDealsCount { get; set; }

        [JsonProperty("closed_deals_count")]
        public long ClosedDealsCount { get; set; }

        [JsonProperty("related_closed_deals_count")]
        public long RelatedClosedDealsCount { get; set; }

        [JsonProperty("participant_open_deals_count")]
        public long ParticipantOpenDealsCount { get; set; }

        [JsonProperty("participant_closed_deals_count")]
        public long ParticipantClosedDealsCount { get; set; }

        [JsonProperty("email_messages_count")]
        public long EmailMessagesCount { get; set; }

        [JsonProperty("activities_count")]
        public long ActivitiesCount { get; set; }

        [JsonProperty("done_activities_count")]
        public long DoneActivitiesCount { get; set; }

        [JsonProperty("undone_activities_count")]
        public long UndoneActivitiesCount { get; set; }

        [JsonProperty("reference_activities_count")]
        public long ReferenceActivitiesCount { get; set; }

        [JsonProperty("files_count")]
        public long FilesCount { get; set; }

        [JsonProperty("notes_count")]
        public long NotesCount { get; set; }

        [JsonProperty("followers_count")]
        public long FollowersCount { get; set; }

        [JsonProperty("won_deals_count")]
        public long WonDealsCount { get; set; }

        [JsonProperty("related_won_deals_count")]
        public long RelatedWonDealsCount { get; set; }

        [JsonProperty("lost_deals_count")]
        public long LostDealsCount { get; set; }

        [JsonProperty("related_lost_deals_count")]
        public long RelatedLostDealsCount { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("phone")]
        public List<Phone> Phone { get; set; }

        [JsonProperty("email")]
        public List<Email> Email { get; set; }

        [JsonProperty("first_char")]
        public char FirstChar { get; set; }

        [JsonProperty("add_time")]
        public DateTime? AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }

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

        [JsonProperty("label")]
        public long? Label { get; set; }

        [JsonProperty("org_name")]
        public string OrgName { get; set; }

        [JsonProperty("owner_name")]
        public string OwnerName { get; set; }

        [JsonProperty("cc_email")]
        public string CcEmail { get; set; }
    }
}
