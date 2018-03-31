using System;

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

        public static IPipedriveClient GetAuthenticatedClient(bool useSecondUser = false)
        {
            return new PipedriveClient(new ProductHeaderValue("PipedriveTests"), ApiUrl, ApiToken);
        }
    }
}
