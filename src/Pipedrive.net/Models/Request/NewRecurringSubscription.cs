using System;

namespace Pipedrive
{
    public class NewRecurringSubscription
    {
        public long DealId { get; set; }

        public string Currency { get; set; }

        public string Description { get; set; }

        public string CadenceType { get; set; }

        public long CyclesCount { get; set; }

        public long CycleAmount { get; set; }

        public DateTime StartDate { get; set; }

        public bool Infinite { get; set; }

        // TODO: add payments
        // public Payment[] Payments { get; set; }

        public bool UpdateDealValue { get; set; }
    }
}
