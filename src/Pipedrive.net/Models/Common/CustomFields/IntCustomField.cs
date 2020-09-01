namespace Pipedrive.CustomFields
{
    // int
    public class IntCustomField : ICustomField
    {
        public int Value { get; set; }

        public IntCustomField(int value)
        {
            Value = value;
        }
    }
}
