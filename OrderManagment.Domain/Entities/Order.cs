namespace OrderManagment.Domain.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
        public virtual Billing Billing { get; set; }
        public virtual Customer Customer { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
    }
}
