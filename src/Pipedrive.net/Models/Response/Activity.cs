using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Pipedrive
{
    public class Activity : IDealUpdateEntity
    {
        public long Id { get; set; }

        [JsonProperty("company_id")]
        public long CompanyId { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("done")]
        public bool Done { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("reference_type")]
        public string ReferenceType { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; }

        [JsonProperty("due_date")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("due_time")]
        public string DueTime { get; set; }

        [JsonProperty("duration")]
        public string Duration { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("marked_as_done_time")]
        public DateTime? MarkedAsDoneTime { get; set; }

        [JsonProperty("last_notification_time")]
        public DateTime? LastNotificationTime { get; set; }

        [JsonProperty("last_notification_user_id")]
        public long? LastNotificationUserId { get; set; }

        [JsonProperty("notification_language_id")]
        public long? NotificationLanguageId { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("org_id")]
        public long? OrgId { get; set; }

        [JsonProperty("person_id")]
        public long? PersonId { get; set; }

        [JsonProperty("deal_id")]
        public long? DealId { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }

        [JsonProperty("update_user_id")]
        public long? UpdateUserId { get; set; }

        [JsonProperty("gcal_event_id")]
        public string GcalEventId { get; set; }

        [JsonProperty("google_calendar_id")]
        public string GoogleCalendarId { get; set; }

        [JsonProperty("google_calendar_etag")]
        public string GoogleCalendarEtag { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("created_by_user_id")]
        public long CreatedByUserId { get; set; }

        [JsonProperty("participants")]
        public List<Participant> Participants { get; set; }

        [JsonProperty("org_name")]
        public string OrgName { get; set; }

        [JsonProperty("person_name")]
        public string PersonName { get; set; }

        [JsonProperty("deal_title")]
        public string DealTitle { get; set; }

        [JsonProperty("owner_name")]
        public string OwnerName { get; set; }

        [JsonProperty("person_dropbox_bcc")]
        public string PersonDropboxBcc { get; set; }

        [JsonProperty("deal_dropbox_bcc")]
        public string DealDropboxBcc { get; set; }

        [JsonProperty("assigned_to_user_id")]
        public long? AssignedToUserId { get; set; }

        public ActivityUpdate ToUpdate()
        {
            return new ActivityUpdate
            {
                Subject = Subject,
                Done = Done ? ActivityDone.Done : ActivityDone.Undone,
                Type = Type,
                DueDate = DueDate,
                DueTime = DueTime,
                Duration = Duration,
                UserId = UserId,
                DealId = DealId,
                PersonId = PersonId,
                Participants = Participants,
                OrgId = OrgId,
                Note = Note
            };
        }
    }
}
