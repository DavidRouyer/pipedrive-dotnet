using Newtonsoft.Json;

namespace Pipedrive
{
    public class Participant
    {
        [JsonProperty("person_id")]
        public long PersonId { get; set; }

        [JsonProperty("primary_flag")]
        public bool PrimaryFlag { get; set; }
    }
}
