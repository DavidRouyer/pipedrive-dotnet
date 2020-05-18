namespace Pipedrive
{
    public class RawFile
    {
        public string Name { get; set; }

        public byte[] Content { get; set; }

        public string ContentType { get; set; }

        public RawFile(string name, byte[] content, string contentType)
        {
            this.Name = name;
            this.Content = content;
            this.ContentType = contentType;
        }
    }
}
