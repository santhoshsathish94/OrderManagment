namespace OrderManagment.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public int BillingId { get; set; }
        public int CustomerId { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
