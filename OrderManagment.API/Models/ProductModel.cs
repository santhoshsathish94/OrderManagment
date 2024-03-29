﻿namespace OrderManagment.API.Models
{
    public class ProductModel
    {
        public int ProductId { get; }
        public string ProductName { get; set; } = string.Empty;
        public string? ProductDiscription { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
