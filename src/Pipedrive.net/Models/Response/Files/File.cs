using System;
using Newtonsoft.Json;

namespace Pipedrive
{
    public class File : IDealUpdateEntity
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

        [JsonProperty("product_id")]
        public long? ProductId { get; set; }

        [JsonProperty("email_message_id")]
        public long? EmailMessageId { get; set; }

        [JsonProperty("activity_id")]
        public long? ActivityId { get; set; }

        [JsonProperty("note_id")]
        public long? NoteId { get; set; }

        [JsonProperty("log_id")]
        public long? LogId { get; set; }

        [JsonProperty("add_time")]
        public DateTime? AddTime { get; set; }

        [JsonProperty("update_time")]
        public DateTime? UpdateTime { get; set; }

        [JsonProperty("file_name")]
        public string FileName { get; set; }

        [JsonProperty("file_type")]
        public string FileType { get; set; }

        [JsonProperty("file_size")]
        public long FileSize { get; set; }

        [JsonProperty("active_flag")]
        public bool ActiveFlag { get; set; }

        [JsonProperty("inline_flag")]
        public bool InlineFlag { get; set; }

        [JsonProperty("remote_location")]
        public string RemoteLocation { get; set; }

        [JsonProperty("remote_id")]
        public string RemoteId { get; set; }

        [JsonProperty("cid")]
        public string Cid { get; set; }

        [JsonProperty("s3_bucket")]
        public string S3Bucket { get; set; }

        [JsonProperty("mail_message_id")]
        public long? MailMessageId { get; set; }

        [JsonProperty("deal_name")]
        public string DealName { get; set; }

        [JsonProperty("person_name")]
        public string PersonName { get; set; }

        [JsonProperty("people_name")]
        public string PeopleName { get; set; }

        [JsonProperty("org_name")]
        public string OrgName { get; set; }

        [JsonProperty("product_name")]
        public string ProductName { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public FileUpdate ToUpdate()
        {
            return new FileUpdate
            {
                Name = Name,
                Description = Description
            };
        }
    }
}
