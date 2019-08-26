namespace Pipedrive.CustomFields
{
    // int
    public class IntCustomField : ICustomField
    {
        public long Value { get; set; }

        public IntCustomField(long value)
        {
            Value = value;
        }
    }
}
