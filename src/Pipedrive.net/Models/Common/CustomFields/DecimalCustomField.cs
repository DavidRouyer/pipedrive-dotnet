namespace Pipedrive.CustomFields
{
    public class DecimalCustomField : ICustomField
    {
        public decimal Value { get; set; }

        public DecimalCustomField(decimal value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
