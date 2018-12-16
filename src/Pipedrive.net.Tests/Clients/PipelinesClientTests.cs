using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class PipelinesClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new PipelinesClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PipelinesClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Pipeline>(Arg.Is<Uri>(u => u.ToString() == "pipelines"));
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PipelinesClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<Pipeline>(Arg.Is<Uri>(u => u.ToString() == "pipelines/123"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new PipelinesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PipelinesClient(connection);

                var newPipeline = new NewPipeline("name");

                client.Create(newPipeline);

                connection.Received().Post<Pipeline>(Arg.Is<Uri>(u => u.ToString() == "pipelines"),
                    Arg.Is<NewPipeline>(nc => nc.Name == "name"));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new PipelinesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PipelinesClient(connection);

                var editPipeline = new PipelineUpdate { Name = "name" };
                client.Edit(123, editPipeline);

                connection.Received().Put<Pipeline>(Arg.Is<Uri>(u => u.ToString() == "pipelines/123"),
                    Arg.Is<PipelineUpdate>(nc => nc.Name == "name"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PipelinesClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "pipelines/123"));
            }
        }

        public class TheGetDealsMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new PipelinesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetDeals(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new PipelinesClient(connection);

                var filters = new PipelineDealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetDeals(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<PipelineDeal>(
                        Arg.Is<Uri>(u => u.ToString() == "pipelines/123/deals"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                            && d["id"] == "123"),
                        Arg.Is<ApiOptions>(o => o.PageSize == 1
                                && o.PageCount == 1
                                && o.StartPage == 0)
                        );
                });
            }
        }
    }
}
