namespace Pipedrive.CustomFields
{
    // varchar, varchar_auto, text
    public class StringCustomField : ICustomField
    {
        public string Value { get; set; }

        public StringCustomField(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
