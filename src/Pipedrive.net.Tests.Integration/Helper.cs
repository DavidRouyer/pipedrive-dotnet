using System;
using System.IO;
using System.Reflection;

namespace Pipedrive.Tests.Integration
{
    public static class Helper
    {
        public static Uri ApiUrl { get { return _apiUrl.Value; } }

        public static string ApiToken { get { return Environment.GetEnvironmentVariable("PIPEDRIVE_APITOKEN"); } }

        static readonly Lazy<Uri> _apiUrl = new Lazy<Uri>(() =>
        {
            string uri = Environment.GetEnvironmentVariable("PIPEDRIVE_URL");

            if (uri != null)
            {
                return new Uri(uri);
            }

            return null;
        });

        public static IPipedriveClient GetAuthenticatedClient()
        {
            return new PipedriveClient(new ProductHeaderValue("PipedriveTests"), ApiUrl)
            {
                Credentials = new Credentials(ApiToken, AuthenticationType.ApiToken)
            };
        }

        public static Stream LoadFixture(string fileName)
        {
            var key = "Pipedrive.Tests.Integration.Fixtures." + fileName;
            var stream = typeof(Helper).GetTypeInfo().Assembly.GetManifestResourceStream(key);
            if (stream == null)
            {
                throw new InvalidOperationException(
                    "The file '" + fileName + "' was not found as an embedded resource in the assembly. Failing the test...");
            }
            return stream;
        }
    }
}
