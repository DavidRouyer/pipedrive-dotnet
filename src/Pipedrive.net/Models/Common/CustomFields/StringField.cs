namespace Pipedrive.CustomFields
{
    // varchar, varchar_auto, text
    public class StringField : IField
    {
        public string Value { get; set; }

        public StringField(string value)
        {
            Value = value;
        }
    }
}
