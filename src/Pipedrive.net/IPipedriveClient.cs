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

        IDealFieldsClient DealField { get; }
    }
}
