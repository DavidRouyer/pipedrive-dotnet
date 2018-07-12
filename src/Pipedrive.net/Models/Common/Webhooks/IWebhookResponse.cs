namespace Pipedrive.Webhooks
{
    public interface IWebhookResponse<T>
    {
        long V { get; set; }

        MatchesFilters MatchesFilters { get; set; }

        Meta Meta { get; set; }

        T Previous { get; set; }

        T Current { get; set; }

        string Event { get; set; }

        long Retry { get; set; }
    }
}
