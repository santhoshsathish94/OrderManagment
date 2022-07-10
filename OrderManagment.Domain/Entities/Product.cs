namespace OrderManagment.Domain.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDiscription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
