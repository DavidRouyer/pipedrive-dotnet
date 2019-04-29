using System;
using System.Net.Http;
using System.Threading.Tasks;
using NSubstitute;
using Pipedrive.Clients;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class OAuthClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() =>
                    new OAuthClient(null));
            }
        }

        public class TheGetPipelineLoginUrlMethod
        {
            [Theory]
            [InlineData("https://starwars-sandbox.pipedrive.com", "https://oauth.pipedrive.com/oauth/authorize?client_id=secret")]
            [InlineData("https://api.example.com/any/path/really", "https://oauth.pipedrive.com/oauth/authorize?client_id=secret")]
            [InlineData(null, "https://oauth.pipedrive.com/oauth/authorize?client_id=secret")]
            public void ReturnsProperAuthorizeUrl(string baseAddress, string expectedUrl)
            {
                var connection = Substitute.For<IConnection>();
                connection.BaseAddress.Returns(baseAddress == null ? null : new Uri(baseAddress));
                var client = new OAuthClient(connection);

                var result = client.GetPipedriveLoginUrl(new OAuthLoginRequest("secret"));

                Assert.Equal(new Uri(expectedUrl), result);
            }

            [Fact]
            public void ReturnsUrlWithAllParameters()
            {
                var request = new OAuthLoginRequest("secret")
                {
                    RedirectUri = new Uri("https://example.com/foo?foo=bar"),
                    State = "canARY"
                };
                var connection = Substitute.For<IConnection>();
                connection.BaseAddress.Returns(new Uri("https://oauth.pipedrive.com"));
                var client = new OAuthClient(connection);

                var result = client.GetPipedriveLoginUrl(request);

                Assert.Equal("/oauth/authorize", result.AbsolutePath);
                Assert.Equal("?client_id=secret&redirect_uri=https%3A%2F%2Fexample.com%2Ffoo%3Ffoo%3Dbar&state=canARY", result.Query);
            }
        }

        public class TheCreateAccessTokenMethod
        {
            [Fact]
            public async Task PostsWithCorrectBodyAndContentType()
            {
                var responseToken = new OAuthToken(null, null, null);
                var response = Substitute.For<IApiResponse<OAuthToken>>();
                response.Body.Returns(responseToken);
                var connection = Substitute.For<IConnection>();
                connection.BaseAddress.Returns(new Uri("https://oauth.pipedrive.com/"));
                Uri calledUri = null;
                FormUrlEncodedContent calledBody = null;
                Uri calledHostAddress = null;
                connection.Post<OAuthToken>(
                    Arg.Do<Uri>(uri => calledUri = uri),
                    Arg.Do<object>(body => calledBody = body as FormUrlEncodedContent),
                    "application/json",
                    null,
                    Arg.Do<Uri>(uri => calledHostAddress = uri))
                    .Returns(_ => Task.FromResult(response));
                var client = new OAuthClient(connection);

                var token = await client.CreateAccessToken(new OAuthAccessTokenRequest(
                    "secretid",
                    "secretsecret",
                    "code",
                    new Uri("https://example.com/foo")));

                Assert.Same(responseToken, token);
                Assert.Equal("oauth/token", calledUri.ToString());
                Assert.NotNull(calledBody);
                Assert.Equal("https://oauth.pipedrive.com/", calledHostAddress.ToString());
                Assert.Equal(
                    "client_id=secretid&client_secret=secretsecret&grant_type=authorization_code&code=code&redirect_uri=https%3A%2F%2Fexample.com%2Ffoo",
                    await calledBody.ReadAsStringAsync());
            }
        }

        public class TheRefreshAccessTokenMethod
        {
            [Fact]
            public async Task PostsWithCorrectBodyAndContentType()
            {
                var responseToken = new OAuthToken(null, null, null);
                var response = Substitute.For<IApiResponse<OAuthToken>>();
                response.Body.Returns(responseToken);
                var connection = Substitute.For<IConnection>();
                connection.BaseAddress.Returns(new Uri("https://oauth.pipedrive.com/"));
                Uri calledUri = null;
                FormUrlEncodedContent calledBody = null;
                Uri calledHostAddress = null;
                connection.Post<OAuthToken>(
                    Arg.Do<Uri>(uri => calledUri = uri),
                    Arg.Do<object>(body => calledBody = body as FormUrlEncodedContent),
                    "application/json",
                    null,
                    Arg.Do<Uri>(uri => calledHostAddress = uri))
                    .Returns(_ => Task.FromResult(response));
                var client = new OAuthClient(connection);

                var token = await client.RefreshAccessToken(new OAuthRefreshTokenRequest(
                    "secretid",
                    "secretsecret",
                    "atoken"));

                Assert.Same(responseToken, token);
                Assert.Equal("oauth/token", calledUri.ToString());
                Assert.NotNull(calledBody);
                Assert.Equal("https://oauth.pipedrive.com/", calledHostAddress.ToString());
                Assert.Equal(
                    "client_id=secretid&client_secret=secretsecret&refresh_token=atoken&grant_type=refresh_token",
                    await calledBody.ReadAsStringAsync());
            }
        }
    }
}
