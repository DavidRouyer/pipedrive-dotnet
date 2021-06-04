using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSubstitute;
using Xunit;

namespace Pipedrive.Tests.Clients
{
    public class ActivityTypesClientTests
    {
        public class TheCtor
        {
            [Fact]
            public void EnsuresNonNullArguments()
            {
                Assert.Throws<ArgumentNullException>(() => new ActivityTypesClient(null));
            }
        }

        public class TheGetAllMethod
        {
            [Fact]
            public async Task RequestsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ActivityTypesClient(connection);

                await client.GetAll();

                Received.InOrder(async () =>
                {
                    await connection.GetAll<ActivityType>(Arg.Is<Uri>(u => u.ToString() == "activityTypes"));
                });
            }
        }

        public class TheCreateMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ActivityTypesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Create(null));
            }

            [Fact]
            public void PostsToTheCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ActivityTypesClient(connection);

                var newActivityType = new NewActivityType("name", ActivityTypeIcon.Bell);
                client.Create(newActivityType);

                connection.Received().Post<ActivityType>(Arg.Is<Uri>(u => u.ToString() == "activityTypes"),
                    Arg.Is<NewActivityType>(nc => nc.Name == "name"
                        && nc.IconKey == ActivityTypeIcon.Bell));
            }
        }

        public class TheEditMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ActivityTypesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Edit(1, null));
            }

            [Fact]
            public void PutsCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ActivityTypesClient(connection);

                var editActivityType = new ActivityTypeUpdate { Name = "name", IconKey = ActivityTypeIcon.Linegraph };
                client.Edit(123, editActivityType);

                connection.Received().Put<ActivityType>(Arg.Is<Uri>(u => u.ToString() == "activityTypes/123"),
                    Arg.Is<ActivityTypeUpdate>(nc => nc.Name == "name"
                        && nc.IconKey == ActivityTypeIcon.Linegraph));
            }
        }

        public class TheDeleteMethod
        {
            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ActivityTypesClient(connection);

                client.Delete(123);

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "activityTypes/123"));
            }
        }

        public class TheDeleteMultipleMethod
        {
            [Fact]
            public async Task EnsuresNonNullArguments()
            {
                var client = new ActivityTypesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentNullException>(() => client.Delete(null));
            }

            [Fact]
            public async Task EnsuresNonEmptyArguments()
            {
                var client = new ActivityTypesClient(Substitute.For<IApiConnection>());

                await Assert.ThrowsAsync<ArgumentException>(() => client.Delete(new List<long>()));
            }

            [Fact]
            public void DeletesCorrectUrl()
            {
                var connection = Substitute.For<IApiConnection>();
                var client = new ActivityTypesClient(connection);

                client.Delete(new List<long>() { 123, 456 });

                connection.Received().Delete(Arg.Is<Uri>(u => u.ToString() == "activityTypes?ids=123,456"));
            }
        }
    }
}
