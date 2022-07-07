using Microsoft.AspNetCore.Mvc;

namespace OrderManagment.API.Models
{
    public class OrderModel 
    {
        public Guid Id { get; }
        public string? OrderNumber { get; }
        public int CustomerId { get; set; }
        public IEnumerable<OrderItemModel> OrderItems { get; set; } = Enumerable.Empty<OrderItemModel>();

    }

    public class OrderItemModel
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

    }
}
