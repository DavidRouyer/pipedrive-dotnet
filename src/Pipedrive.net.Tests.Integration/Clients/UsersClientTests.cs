using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class UsersClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveUsers()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var users = await pipedrive.User.GetAll();

                Assert.True(users.Count >= 1);
                Assert.True(users[0].ActiveFlag);
                Assert.True(users[0].Activated);
            }
        }

        public class TheGetByNameMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveUsers()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var users = await pipedrive.User.GetByName("david rouyer");

                Assert.True(users.Count == 1);
                Assert.True(users[0].ActiveFlag);
                Assert.True(users[0].Activated);
            }
        }

        public class TheGetByEmailMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveUsers()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var users = await pipedrive.User.GetByEmail("david@hopfab.com");

                Assert.True(users.Count == 1);
                Assert.True(users[0].ActiveFlag);
                Assert.True(users[0].Activated);
            }
        }

        public class TheGetMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveDealField()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var dealField = await pipedrive.User.Get(2616956);

                Assert.True(dealField.ActiveFlag);
                Assert.True(dealField.Activated);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.User;

                var newUser = new NewUser("name", "test@example.com", false);

                var user = await fixture.Create(newUser);
                Assert.NotNull(user);

                var retrieved = await fixture.Get(user.Id);
                Assert.NotNull(retrieved);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.User;

                var newUser = new NewUser("new-name", "test@example.com", false);
                var user = await fixture.Create(newUser);

                var editUser = user.ToUpdate();
                editUser.Name = "updated-name";
                editUser.Email = "test@starwars.com";

                await Assert.ThrowsAsync<NotImplementedException>(() => fixture.Edit(user.Id, editUser));
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.User;

                var newUser = new NewUser("new-name", "test@example.com", false);
                var user = await fixture.Create(newUser);

                var createdUser = await fixture.Get(user.Id);

                Assert.NotNull(createdUser);

                await Assert.ThrowsAsync<NotFoundException>(() => fixture.Delete(createdUser.Id));
            }
        }
    }
}
