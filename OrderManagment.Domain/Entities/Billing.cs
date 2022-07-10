namespace OrderManagment.Domain.Entities
{
    public class Billing
    {
        public int BillingId { get; set; }
        public DateTime BillingDate { get; set; }
        public string BillingNumber { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; }
        public string BillingAddress { get; set; }
        public bool IsPaid { get; set; }
        public BillingType BillingType { get; set; }
        public string TransactionId { get; set; }
    }

    public enum BillingType
    {
        CashOnDeliver,
        CardPayment,
        UPIPayment
    }
}
