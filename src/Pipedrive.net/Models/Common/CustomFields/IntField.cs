namespace Pipedrive.CustomFields
{
    // int
    public class IntField : IField
    {
        public int Value { get; set; }

        public IntField(int value)
        {
            Value = value;
        }
    }
}
