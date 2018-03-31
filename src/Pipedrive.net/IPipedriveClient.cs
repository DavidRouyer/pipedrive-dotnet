using System;

namespace Pipedrive
{
    public interface IPipedriveClient
    {
        void SetRequestTimeout(TimeSpan timeout);

        IConnection Connection { get; }

        ICurrenciesClient Currency { get; }

        IActivityFieldsClient ActivityField { get; }
    }
}
