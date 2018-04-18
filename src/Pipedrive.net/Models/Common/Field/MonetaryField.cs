namespace Pipedrive
{
    public class MonetaryField : IField
    {
        public decimal Value { get; set; }

        public string Currency { get; set; }

        public MonetaryField(decimal value, string currency)
        {
            Value = value;
            Currency = currency;
        }
    }
}
