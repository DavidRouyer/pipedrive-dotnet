using System;
using Pipedrive.Clients;

namespace Pipedrive
{
    public interface IPipedriveClient
    {
        void SetRequestTimeout(TimeSpan timeout);

        ApiInfo GetLastApiInfo();

        IConnection Connection { get; }

        IActivitiesClient Activity { get; }

        IActivityFieldsClient ActivityField { get; }

        IActivityTypesClient ActivityType { get; }

        ICurrenciesClient Currency { get; }

        IDealsClient Deal { get; }

        IDealFieldsClient DealField { get; }

        IFilesClient File { get; }

        ILeadsClient Lead { get; }

        ILeadLabelsClient LeadLabels { get; }

        INotesClient Note { get; }

        INoteFieldsClient NoteField { get; }

        IOrganizationsClient Organization { get; }

        IOrganizationFieldsClient OrganizationField { get; }

        IPersonsClient Person { get; }

        IPersonFieldsClient PersonField { get; }

        IPipelinesClient Pipeline { get; }

        IProductsClient Product { get; }

        IProductFieldsClient ProductField { get; }

        IStagesClient Stage { get; }

        ISubscriptionsClient Subscription { get; }

        IUsersClient User { get; }

        IWebhooksClient Webhook { get; }
    }
}
