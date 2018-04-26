namespace Pipedrive.CustomFields
{
    public class DecimalField : IField
    {
        public decimal Value { get; set; }

        public DecimalField(decimal value)
        {
            Value = value;
        }
    }
}
