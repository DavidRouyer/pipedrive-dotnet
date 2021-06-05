using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class NoteFieldsClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task CanRetrieveNoteFields()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var noteFields = await pipedrive.NoteField.GetAll();

                Assert.True(noteFields.Count >= 2);
                Assert.True(noteFields[0].ActiveFlag);
                Assert.True(noteFields[0].MantatoryFlag);
                Assert.True(noteFields[1].ActiveFlag);
                Assert.False(noteFields[1].MantatoryFlag);
            }
        }
    }
}
