# Pipedrive.net [![Build Status](https://travis-ci.org/DavidRouyer/pipedrive-dotnet.svg?branch=master)](https://travis-ci.org/DavidRouyer/pipedrive-dotnet)

## Getting started

### Set the API Key and URL for your project

In your application initialization, set your API key and organization URL:

```csharp
PipedriveClient client = new PipedriveClient(new ProductHeaderValue("PipedriveExample"), "[your organization url here]", "[your api key here]");
```

You can obtain your secret API key from the API Settings https://[your organization].pipedrive.com/settings#api in Pipedrive.