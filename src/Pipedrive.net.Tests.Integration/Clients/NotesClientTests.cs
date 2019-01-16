using System.Threading.Tasks;
using Xunit;

namespace Pipedrive.Tests.Integration.Clients
{
    public class NotesClientTests
    {
        public class TheGetAllMethod
        {
            [IntegrationTest]
            public async Task ReturnsCorrectCountWithoutStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new NoteFilters
                {
                    PageSize = 3,
                    PageCount = 1
                };

                var notes = await pipedrive.Note.GetAll(options);
                Assert.Equal(3, notes.Count);
            }

            [IntegrationTest]
            public async Task ReturnsCorrectCountWithStart()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var options = new NoteFilters
                {
                    PageSize = 2,
                    PageCount = 1,
                    StartPage = 1
                };

                var notes = await pipedrive.Note.GetAll(options);
                Assert.Equal(2, notes.Count);
            }

            [IntegrationTest]
            public async Task ReturnsDistinctInfosBasedOnStartPage()
            {
                var pipedrive = Helper.GetAuthenticatedClient();

                var startOptions = new NoteFilters
                {
                    PageSize = 1,
                    PageCount = 1
                };

                var firstPage = await pipedrive.Note.GetAll(startOptions);

                var skipStartOptions = new NoteFilters
                {
                    PageSize = 1,
                    PageCount = 1,
                    StartPage = 1
                };

                var secondPage = await pipedrive.Note.GetAll(skipStartOptions);

                Assert.NotEqual(firstPage[0].Id, secondPage[0].Id);
            }
        }

        public class TheCreateMethod
        {
            [IntegrationTest]
            public async Task CanCreate()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Note;

                var newNote = new NewNote("content");
                newNote.DealId = 1;

                var note = await fixture.Create(newNote);
                Assert.NotNull(note);

                var retrieved = await fixture.Get(note.Id);
                Assert.NotNull(retrieved);

                // Cleanup
                await fixture.Delete(note.Id);
            }
        }

        public class TheEditMethod
        {
            [IntegrationTest]
            public async Task CanEdit()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Note;

                var newNote = new NewNote("new-content");
                newNote.DealId = 1;

                var note = await fixture.Create(newNote);

                var editNote = note.ToUpdate();
                editNote.Content = "updated-content";

                var updatedNote = await fixture.Edit(note.Id, editNote);

                Assert.Equal("updated-content", updatedNote.Content);

                // Cleanup
                await fixture.Delete(updatedNote.Id);
            }
        }

        public class TheDeleteMethod
        {
            [IntegrationTest]
            public async Task CanDelete()
            {
                var pipedrive = Helper.GetAuthenticatedClient();
                var fixture = pipedrive.Note;

                var newNote = new NewNote("new-content");
                newNote.DealId = 1;

                var note = await fixture.Create(newNote);

                var createdNote = await fixture.Get(note.Id);

                Assert.NotNull(createdNote);

                await fixture.Delete(createdNote.Id);

                var deletedNote = await fixture.Get(createdNote.Id);

                Assert.False(deletedNote.ActiveFlag);
            }
        }
    }
}
