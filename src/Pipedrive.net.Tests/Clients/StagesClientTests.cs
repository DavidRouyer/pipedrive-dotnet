using NSubstitute;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class StagesClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new StagesClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new StagesClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Stage>(
                        Arg.Is<Uri>(u => u.ToString() == "stages"));
                });
            }
        }

        public class TheGetAllForPipelineIdMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new StagesClient(connection);

                await client.GetAllForPipelineId(1);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<Stage>(
                        Arg.Is<Uri>(u => u.ToString() == "stages"),
                        Arg.Is<Dictionary<string, string>>(d => d.Count == 1
                                && d["pipeline_id"] == "1"));
                });
            }
        }

        public class TheGetMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new StagesClient(connection);

                await client.Get(123);

                Received.InOrder(async () =>
                {
                    await connection.Get<Stage>(Arg.Is<Uri>(u => u.ToString() == "stages/123"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new StagesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new StagesClient(connection);

                var newStage = new NewStage("name", 1);

                client.Create(newStage);

                connection.Received().Post<Stage>(Arg.Is<Uri>(u => u.ToString() == "stages"),
                    Arg.Is<NewStage>(nc => nc.Name == "name" && nc.PipelineId == 1));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new StagesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new StagesClient(connection);

                var editStage = new StageUpdate { Name = "name" };
                client.Edit(123, editStage);

                connection.Received().Put<Stage>(Arg.Is<Uri>(u => u.ToString() == "stages/123"),
                    Arg.Is<StageUpdate>(nc => nc.Name == "name"));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new StagesClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "stages/123"));
            }
        }

        public class TheGetDealsMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new StagesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.GetDeals(1, null));
            }

            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new StagesClient(connection);

                var filters = new StageDealFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 0,
                };

                await client.GetDeals(123, filters);

                Received.InOrder(async () =>
                {
                    await connection.GetAll<PipelineDeal>(
                        Arg.Is<Uri>(u => u.ToString() == "stages/123/deals"),
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
