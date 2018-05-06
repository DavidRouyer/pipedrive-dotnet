using Newtonsoft.Json;
using System.IO;

namespace Pipedrive
{
    public class NewFile
    {
        public Stream File { get; set; }
        
        public long? DealId { get; set; }

        public long? PersonId { get; set; }

        public long? OrgId { get; set; }

        public long? ProductId { get; set; }

        public long? ActivityId { get; set; }

        public long? NoteId { get; set; }

        public NewFile(Stream file)
        {
            this.File = file;
        }
    }
}
