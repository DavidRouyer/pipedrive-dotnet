using Newtonsoft.Json;

namespace Pipedrive
{
    public class MailMessageRecipient
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("linked_person_id")]
        public string LinkedPersonId { get; set; }

        [JsonProperty("linked_person_name")]
        public string LinkedPersonName { get; set; }

        [JsonProperty("mail_message_party_id")]
        public long MailMessagePartyId { get; set; }
    }
}
