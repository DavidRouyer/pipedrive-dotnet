using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Pipedrive.Tests.Integration
{
    public class IntegrationTestDiscoverer : IXunitTestCaseDiscoverer
    {
        readonly IMessageSink diagnosticMessageSink;

        public IntegrationTestDiscoverer(IMessageSink diagnosticMessageSink)
        {
            this.diagnosticMessageSink = diagnosticMessageSink;
        }

        public IEnumerable<IXunitTestCase> Discover(ITestFrameworkDiscoveryOptions discoveryOptions, ITestMethod testMethod, IAttributeInfo factAttribute)
        {
            return new[] { new XunitTestCase(diagnosticMessageSink, discoveryOptions.MethodDisplayOrDefault(), discoveryOptions.MethodDisplayOptionsOrDefault(), testMethod) };
        }
    }

    [XunitTestCaseDiscoverer("Pipedrive.Tests.Integration.IntegrationTestDiscoverer", "Pipedrive.Tests.Integration")]
    public class IntegrationTestAttribute : FactAttribute
    {
    }
}
