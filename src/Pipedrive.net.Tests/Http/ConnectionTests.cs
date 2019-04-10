using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NSubstitute;
using Pipedrive.Internal;
using Xunit;

namespace Pipedrive.Tests.Http
{
    public class ConnectionTests
    {
        const string exampleUrl = "http://example.com";
        static readonly string exampleToken = "test";
        static readonly ICredentialStore _credentialStore = new InMemoryCredentialStore(new Credentials("test", AuthenticationType.ApiToken));
        static readonly Uri _exampleUri = new Uri(exampleUrl);

        public class TheGetMethod
        {
            [Fact]
            public async Task SendsProperlyFormattedRequest()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response();
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative));

                httpClient.Received(1).Send(Arg.Is<IRequest>(req =>
                    req.BaseAddress == _exampleUri &&
                    req.ContentType == null &&
                    req.Body == null &&
                    req.Method == HttpMethod.Get &&
                    req.Endpoint == new Uri($"endpoint?api_token={exampleToken}", UriKind.Relative)), Args.CancellationToken);
            }

            [Fact]
            public async Task CanMakeMultipleRequestsWithSameConnection()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response();
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative));
                await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative));
                await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative));

                httpClient.Received(3).Send(Arg.Is<IRequest>(req =>
                    req.BaseAddress == _exampleUri &&
                    req.Method == HttpMethod.Get &&
                    req.Endpoint == new Uri($"endpoint?api_token={exampleToken}", UriKind.Relative)), Args.CancellationToken);
            }

            [Fact]
            public async Task ParsesApiInfoOnResponse()
            {
                var httpClient = Substitute.For<IHttpClient>();
                var headers = new Dictionary<string, string>();
                IResponse response = new Response(headers);

                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                var resp = await connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative));
                Assert.NotNull(resp.HttpResponse.ApiInfo);
            }

            [Fact]
            public async Task ThrowsAuthorizationExceptionExceptionForUnauthorizedResponse()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(HttpStatusCode.Unauthorized, null, new Dictionary<string, string>(), "application/json");
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                var exception = await Assert.ThrowsAsync<AuthorizationException>(
                    () => connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));
                Assert.NotNull(exception);
            }

            [Fact]
            public async Task ThrowsApiValidationExceptionFor422Response()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(
                    (HttpStatusCode)422,
                    @"{""errors"":[{""code"":""custom"",""field"":""key"",""message"":""key is " +
                    @"already in use"",""resource"":""PublicKey""}],""message"":""Validation Failed""}",
                    new Dictionary<string, string>(),
                    "application/json"
                );
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                var exception = await Assert.ThrowsAsync<ApiValidationException>(
                    () => connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));

                Assert.Equal("Validation Failed", exception.Message);
            }

            [Fact]
            public async Task ThrowsRateLimitExceededExceptionForForbidderResponse()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(
                    HttpStatusCode.Forbidden,
                    "{\"error\":\"API rate limit exceeded. " +
                    "See https://developers.pipedrive.com/docs/api/v1/#/ for details.\"}",
                    new Dictionary<string, string>(),
                    "application/json");
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                var exception = await Assert.ThrowsAsync<RateLimitExceededException>(
                    () => connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));

                Assert.Equal("API rate limit exceeded. See https://developers.pipedrive.com/docs/api/v1/#/ for details.",
                    exception.Message);
            }

            [Fact]
            public async Task ThrowsLoginAttemptsExceededExceptionForForbiddenResponse()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(
                    HttpStatusCode.Forbidden,
                    "{\"error\":\"Maximum number of login attempts exceeded\"," +
                    "\"error_info\":\"http://developer.github.com/v3\"}",
                    new Dictionary<string, string>(),
                    "application/json");
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                var exception = await Assert.ThrowsAsync<LoginAttemptsExceededException>(
                    () => connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));

                Assert.Equal("Maximum number of login attempts exceeded", exception.Message);
                Assert.Equal("http://developer.github.com/v3", exception.ApiError.ErrorInfo);
            }

            [Fact]
            public async Task ThrowsNotFoundExceptionForFileNotFoundResponse()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(
                    HttpStatusCode.NotFound,
                    "GONE BYE BYE!",
                    new Dictionary<string, string>(),
                    "application/json");

                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                var exception = await Assert.ThrowsAsync<NotFoundException>(
                    () => connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));

                Assert.Equal("GONE BYE BYE!", exception.Message);
            }

            [Fact]
            public async Task ThrowsForbiddenExceptionForUnknownForbiddenResponse()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(
                    HttpStatusCode.Forbidden,
                    "YOU SHALL NOT PASS!",
                    new Dictionary<string, string>(),
                    "application/json");
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                var exception = await Assert.ThrowsAsync<ForbiddenException>(
                    () => connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));

                Assert.Equal("YOU SHALL NOT PASS!", exception.Message);
            }

            [Fact]
            public async Task ThrowsAbuseExceptionForResponseWithAbuseDocumentationLink()
            {
                var messageText = "blahblahblah this does not matter because we are testing the URL";

                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(
                    HttpStatusCode.Forbidden,
                    "{\"message\":\"" + messageText + "\"," +
                    "\"documentation_url\":\"https://developer.github.com/v3/#abuse-rate-limits\"}",
                    new Dictionary<string, string>(),
                    "application/json");
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                await Assert.ThrowsAsync<AbuseException>(
                    () => connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));
            }

            [Fact]
            public async Task ThrowsAbuseExceptionForResponseWithAbuseDescription()
            {
                var messageText = "You have triggered an abuse detection mechanism. Please wait a few minutes before you try again.";

                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(
                    HttpStatusCode.Forbidden,
                    "{\"message\":\"" + messageText + "\"," +
                    "\"documentation_url\":\"https://ThisURLDoesNotMatter.com\"}",
                    new Dictionary<string, string>(),
                    "application/json");
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                await Assert.ThrowsAsync<AbuseException>(
                    () => connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));
            }


            [Fact]
            public async Task AbuseExceptionContainsTheRetryAfterHeaderAmount()
            {
                var messageText = "You have triggered an abuse detection mechanism. Please wait a few minutes before you try again.";

                var httpClient = Substitute.For<IHttpClient>();
                var headerDictionary = new Dictionary<string, string>
                {
                    { "Retry-After", "45" }
                };

                IResponse response = new Response(
                    HttpStatusCode.Forbidden,
                    "{\"message\":\"" + messageText + "\"," +
                    "\"documentation_url\":\"https://ThisURLDoesNotMatter.com\"}",
                    headerDictionary,
                    "application/json");
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                var exception = await Assert.ThrowsAsync<AbuseException>(
                    () => connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));

                Assert.Equal(45, exception.RetryAfterSeconds);
            }

            [Fact]
            public async Task ThrowsAbuseExceptionWithDefaultMessageForUnsafeAbuseResponse()
            {
                string messageText = string.Empty;

                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response(
                    HttpStatusCode.Forbidden,
                     "{\"message\":\"" + messageText + "\"," +
                    "\"documentation_url\":\"https://developer.github.com/v3/#abuse-rate-limits\"}",
                   new Dictionary<string, string>(),
                    "application/json");
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                var exception = await Assert.ThrowsAsync<AbuseException>(
                    () => connection.GetResponse<string>(new Uri("endpoint", UriKind.Relative)));

                Assert.Equal("Request Forbidden - Abuse Detection", exception.Message);
            }
        }

        public class ThePutMethod
        {
            [Fact]
            public async Task MakesPutRequestWithData()
            {
                var body = new object();
                var expectedBody = JsonConvert.SerializeObject(body);
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response();

                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                await connection.Put<string>(new Uri("endpoint", UriKind.Relative), body);

                httpClient.Received(1).Send(Arg.Is<IRequest>(req =>
                    req.BaseAddress == _exampleUri &&
                    (string)req.Body == expectedBody &&
                    req.Method == HttpMethod.Put &&
                    req.ContentType == "application/json" &&
                    req.Endpoint == new Uri($"endpoint?api_token={exampleToken}", UriKind.Relative)), Args.CancellationToken);
            }

            [Fact]
            public async Task MakesPutRequestWithNoData()
            {
                var body = RequestBody.Empty;
                var expectedBody = JsonConvert.SerializeObject(body);
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response();

                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));

                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                await connection.Put<string>(new Uri("endpoint", UriKind.Relative), body);

                httpClient.Received(1).Send(Arg.Is<IRequest>(req =>
                    req.BaseAddress == _exampleUri &&
                    (string)req.Body == expectedBody &&
                    req.Method == HttpMethod.Put &&
                    req.Endpoint == new Uri($"endpoint?api_token={exampleToken}", UriKind.Relative)), Args.CancellationToken);
            }
        }

        public class ThePostMethod
        {
            [Fact]
            public async Task SendsProperlyFormattedPostRequest()
            {
                var body = new object();
                var data = JsonConvert.SerializeObject(body);
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response();

                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                await connection.Post<string>(new Uri("endpoint", UriKind.Relative), body, null, null);

                httpClient.Received(1).Send(Arg.Is<IRequest>(req =>
                    req.BaseAddress == _exampleUri &&
                    req.ContentType == "application/json" &&
                    (string)req.Body == data &&
                    req.Method == HttpMethod.Post &&
                    req.Endpoint == new Uri($"endpoint?api_token={exampleToken}", UriKind.Relative)), Args.CancellationToken);
            }

            [Fact]
            public async Task SendsProperlyFormattedPostRequestWithCorrectHeaders()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response();
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                var body = new MemoryStream(new byte[] { 48, 49, 50 });
                await connection.Post<string>(
                    new Uri("https://other.host.com/path?query=val"),
                    body,
                    null,
                    "application/arbitrary");

                httpClient.Received().Send(Arg.Is<IRequest>(req =>
                    req.BaseAddress == _exampleUri &&
                    req.Body == body &&
                    req.Headers["Accept"] == "application/json" &&
                    req.ContentType == "application/arbitrary" &&
                    req.Method == HttpMethod.Post &&
                    req.Endpoint == new Uri($"https://other.host.com/path?api_token={exampleToken}&query=val")), Args.CancellationToken);
            }

            [Fact]
            public async Task SetsAcceptsHeader()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response();
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);
                var body = new MemoryStream(new byte[] { 48, 49, 50 });

                await connection.Post<string>(
                    new Uri("https://other.host.com/path?query=val"),
                    body,
                    "application/json",
                    null);

                httpClient.Received().Send(Arg.Is<IRequest>(req =>
                    req.Headers["Accept"] == "application/json" &&
                    req.ContentType == "application/json"), Args.CancellationToken);
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public async Task SendsProperlyFormattedDeleteRequest()
            {
                var httpClient = Substitute.For<IHttpClient>();
                IResponse response = new Response();
                httpClient.Send(Args.Request, Args.CancellationToken).Returns(Task.FromResult(response));
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    _credentialStore,
                    httpClient);

                await connection.Delete(new Uri("endpoint", UriKind.Relative));

                httpClient.Received(1).Send(Arg.Is<IRequest>(req =>
                    req.BaseAddress == _exampleUri &&
                    req.Body == null &&
                    req.ContentType == null &&
                    req.Method == HttpMethod.Delete &&
                    req.Endpoint == new Uri($"endpoint?api_token={exampleToken}", UriKind.Relative)), Args.CancellationToken);
            }
        }

        public class TheConstructor
        {
            [Fact]
            public void EnsuresAbsoluteBaseAddress()
            {
                Assert.Throws<ArgumentException>(() =>
                    new Connection(new ProductHeaderValue("TestRunner"), new Uri("foo", UriKind.Relative)));
                Assert.Throws<ArgumentException>(() =>
                    new Connection(new ProductHeaderValue("TestRunner"), new Uri("foo", UriKind.RelativeOrAbsolute)));
            }

            [Fact]
            public void EnsuresNonNullArguments()
            {
                // 2 args
                Assert.Throws<ArgumentNullException>(() => new Connection(null, new Uri("https://example.com")));
                Assert.Throws<ArgumentNullException>(() => new Connection(new ProductHeaderValue("foo"), null));

                // 3 args
                Assert.Throws<ArgumentNullException>(() => new Connection(null,
                    new Uri("https://example.com"),
                    Substitute.For<ICredentialStore>()));
                Assert.Throws<ArgumentNullException>(() => new Connection(new ProductHeaderValue("foo"),
                    null,
                    Substitute.For<ICredentialStore>()));
                Assert.Throws<ArgumentNullException>(() => new Connection(new ProductHeaderValue("foo"),
                    new Uri("https://example.com"),
                    null));

                // 4 Args
                Assert.Throws<ArgumentNullException>(() => new Connection(null,
                    new Uri("https://example.com"),
                    Substitute.For<ICredentialStore>(),
                    Substitute.For<IHttpClient>()));
                Assert.Throws<ArgumentNullException>(() => new Connection(new ProductHeaderValue("foo"),
                    null,
                    Substitute.For<ICredentialStore>(),
                    Substitute.For<IHttpClient>()));
                Assert.Throws<ArgumentNullException>(() => new Connection(new ProductHeaderValue("foo"),
                    new Uri("https://example.com"),
                    null,
                    Substitute.For<IHttpClient>()));
                Assert.Throws<ArgumentNullException>(() => new Connection(new ProductHeaderValue("foo"),
                    new Uri("https://example.com"),
                    Substitute.For<ICredentialStore>(),
                    null));
            }

            [Fact]
            public void CreatesConnectionWithBaseAddress()
            {
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"), new Uri("https://github.com/"));

                Assert.Equal(new Uri("https://github.com/"), connection.BaseAddress);
                Assert.StartsWith("PipedriveTests (", connection.UserAgent);
            }
        }

        public class TheLastAPiInfoProperty
        {
            [Fact]
            public async Task ReturnsNullIfNew()
            {
                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri);

                var result = connection.GetLastApiInfo();

                Assert.Null(result);
            }

            // TODO: uncomment
            /*[Fact]
            public async Task ReturnsObjectIfNotNew()
            {
                var apiInfo = new ApiInfo(
                                new Dictionary<string, Uri>
                                {
                                    {
                                        "next",
                                        new Uri("https://api.github.com/repos/rails/rails/issues?page=4&per_page=5")
                                    },
                                    {
                                        "last",
                                        new Uri("https://api.github.com/repos/rails/rails/issues?page=131&per_page=5")
                                    },
                                    {
                                        "first",
                                        new Uri("https://api.github.com/repos/rails/rails/issues?page=1&per_page=5")
                                    },
                                    {
                                        "prev",
                                        new Uri("https://api.github.com/repos/rails/rails/issues?page=2&per_page=5")
                                    }
                                },
                                "5634b0b187fd2e91e3126a75006cc4fa",
                                new RateLimit(100, 75, 1372700873)
                            );

                var httpClient = Substitute.For<IHttpClient>();

                // We really only care about the ApiInfo property...
                var expectedResponse = new Response(HttpStatusCode.OK, null, new Dictionary<string, string>(), "application/json")
                {
                    ApiInfo = apiInfo
                };

                httpClient.Send(Arg.Any<IRequest>(), Arg.Any<CancellationToken>())
                    .Returns(Task.FromResult<IResponse>(expectedResponse));

                var connection = new Connection(new ProductHeaderValue("PipedriveTests"),
                    _exampleUri,
                    httpClient,
                    "exampleToken");

                connection.Get<PullRequest>(new Uri("https://example.com"), TimeSpan.MaxValue);

                var result = connection.GetLastApiInfo();

                // No point checking all of the values as they are tested elsewhere
                // Just provde that the ApiInfo is populated
                Assert.Equal(4, result.Links.Count);
                Assert.Equal("5634b0b187fd2e91e3126a75006cc4fa", result.Etag);
                Assert.Equal(100, result.RateLimit.Limit);
            }*/
        }
    }
}
