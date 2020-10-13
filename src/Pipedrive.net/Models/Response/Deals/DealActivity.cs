using Newtonsoft.Json;

namespace Pipedrive
{
    public class DealActivity : AbstractActivity
    {
        [JsonProperty("note_clean")]
        public string NoteClean { get; set; }

        public Activity ToActivity()
        {
            return new Activity
            {
                Subject = Subject,
                Done = Done,
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
