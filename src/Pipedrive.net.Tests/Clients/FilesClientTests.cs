using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class FilesClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new FilesClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new FilesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetAll(null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new FilesClient(connection);

                var filters = new FileFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetAll(filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<File>(
                        Arg.Is<Uri>(u => u.ToString() == "files"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 0),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0)
                        );
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new FilesClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<File>(Arg.Is<Uri>(u => u.ToString() == "files/123"));
                });
            }
        }

        /*public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new FilesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public async Task PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new FilesClient(connection);

                var newFile = new NewFile(new MemoryStream());
                await client.Create(newFile);

                await connection.Received().Post<File>(Arg.Is<Uri>(u => u.ToString() == "files"),
                    Arg.Is<NewFile>(nc => nc.File == new MemoryStream()));
            }
        }*/

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new FilesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new FilesClient(connection);

                var editFile = new FileUpdate { Name = "name", Description = "description" };
                client.Edit(123, editFile);

                connection.Received().Put<File>(Arg.Is<Uri>(u => u.ToString() == "files/123"),
                    Arg.Is<FileUpdate>(nc => nc.Name == "name"
                        && nc.Description == "description"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new FilesClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "files/123"));
            }
        }
    }
}
