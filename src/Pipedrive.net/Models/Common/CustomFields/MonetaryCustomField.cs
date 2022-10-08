namespace Pipedrive.CustomFields
{
    public class MonetaryCustomField : ICustomField
    {
        public decimal Value { get; set; }

        public string Currency { get; set; }

        public MonetaryCustomField(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }

        public override string ToString()
        {
            return $"{Currency} {Value}";
        }
    }
}
