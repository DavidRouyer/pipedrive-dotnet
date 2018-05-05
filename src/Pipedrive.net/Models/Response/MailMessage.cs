using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Pipedrive
{
    public class MailMessage : IDealUpdateEntity
    {
        public long Id { get; set; }

        [JsonProperty("from")]
        public List<MailMessageRecipient> From { get; set; }

        [JsonProperty("to")]
        public List<MailMessageRecipient> To { get; set; }

        [JsonProperty("cc")]
        public List<MailMessageRecipient> Cc { get; set; }

        [JsonProperty("bcc")]
        public List<MailMessageRecipient> Bcc { get; set; }

        [JsonProperty("body_url")]
        public string BodyUrl { get; set; }

        [JsonProperty("nylas_id")]
        public string NylasId { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("user_id")]
        public long UserId { get; set; }

        [JsonProperty("mail_thread_id")]
        public long MailThreadId { get; set; }

        [JsonProperty("subject")]
        public string Subject { get; set; }

        [JsonProperty("snippet")]
        public string Snippet { get; set; }

        [JsonProperty("mail_tracking_status")]
        public string MailTrackingStatus { get; set; }

        [JsonProperty("mail_link_tracking_enabled_flag")]
        public bool MailLinkTrackingEnabledFlag { get; set; }

        [JsonProperty("read_flag")]
        public bool ReadFlag { get; set; }

        [JsonProperty("draft")]
        public string Draft { get; set; }

        [JsonProperty("s3_bucket")]
        public string S3Bucket { get; set; }

        [JsonProperty("draft_flag")]
        public bool DraftFlag { get; set; }

        [JsonProperty("synced_flag")]
        public bool SyncedFlag { get; set; }

        [JsonProperty("deleted_flag")]
        public bool DeletedFlag { get; set; }

        [JsonProperty("has_body_flag")]
        public bool HasBodyFlag { get; set; }

        [JsonProperty("sent_flag")]
        public bool SentFlag { get; set; }

        [JsonProperty("sent_from_pipedrive_flag")]
        public bool SentFromPipedriveFlag { get; set; }

        [JsonProperty("smart_bcc_flag")]
        public bool SmartBccFlag { get; set; }

        [JsonProperty("message_time")]
        public DateTime? MessageTime { get; set; }

        [JsonProperty("add_time")]
        public DateTime AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }

        [JsonProperty("has_attachments_flag")]
        public bool HasAttachmentsFlag { get; set; }

        [JsonProperty("has_inline_attachments_flag")]
        public bool HasInlineAttachmentsFlag { get; set; }

        [JsonProperty("has_real_attachments_flag")]
        public bool HasRealAttachmentsFlag { get; set; }

        [JsonProperty("mua_message_id")]
        public string MuaMessageId { get; set; }

        [JsonProperty("write_flag")]
        public bool WriteFlag { get; set; }

        [JsonProperty("item_type")]
        public string ItemType { get; set; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("company_id")]
        public long? CompanyId { get; set; }
    }
}
