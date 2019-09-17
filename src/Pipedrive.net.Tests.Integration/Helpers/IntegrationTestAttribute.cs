using Xunit;
using Xunit.Sdk;

namespace Pipedrive.Tests.Integration
{
    [XunitTestCaseDiscoverer("Pipedrive.Tests.Integration.IntegrationTestDiscoverer", "Pipedrive.Tests.Integration")]
    public class IntegrationTestAttribute : FactAttribute
    {
    }
}
