namespace Pipedrive
{
    public class Activity : AbstractActivity, IDealUpdateEntity
    {
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
                Note = Note,
            };
        }
    }
}
