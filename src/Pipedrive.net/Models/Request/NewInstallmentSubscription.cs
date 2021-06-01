namespace Pipedrive
{
    public class NewInstallmentSubscription
    {
        public long DealId { get; set; }

        public string Currency { get; set; }

        // TODO: add payments
        // public Payment[] Payments { get; set; }

        public bool UpdateDealValue { get; set; }
    }
}
