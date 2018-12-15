using System;

namespace Pipedrive
{
    public interface IPipedriveClient
    {
        void SetRequestTimeout(TimeSpan timeout);

        IConnection Connection { get; }

        IActivitiesClient Activity { get; }

        IActivityFieldsClient ActivityField { get; }

        IActivityTypesClient ActivityType { get; }

        ICurrenciesClient Currency { get; }

        IDealsClient Deal { get; }

        IDealFieldsClient DealField { get; }

        IFilesClient File { get; }

        INotesClient Note { get; }

        IOrganizationsClient Organization { get; }

        IOrganizationFieldsClient OrganizationField { get; }

        IPersonsClient Person { get; }

        IPersonFieldsClient PersonField { get; }

        IPipelinesClient Pipeline { get; }

        IStagesClient Stage { get; }

        IUsersClient User { get; }

        IWebhooksClient Webhook { get; }
    }
}
