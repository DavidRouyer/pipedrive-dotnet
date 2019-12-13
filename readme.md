# Pipedrive.net ![](https://github.com/DavidRouyer/pipedrive-dotnet/workflows/.NET%20Core%20CI/badge.svg)

## Getting started

### Set the API Key and URL for your project

In your application initialization, set your API key and organization URL:

```csharp
PipedriveClient client = new PipedriveClient(new ProductHeaderValue("PipedriveExample"), new Uri("[your organization url here]"))
{
  Credentials = new Credentials("[your api key here]", AuthenticationType.ApiToken)
};
```

You can obtain your secret API key from the API Settings `https://[your organization].pipedrive.com/settings#api` in Pipedrive.

## Debugging

You can debug this library right from your application by configuring the [NuGet symbol server](https://docs.microsoft.com/en-us/nuget/create-packages/symbol-packages-snupkg#nugetorg-symbol-server).