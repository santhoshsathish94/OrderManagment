﻿namespace OrderManagment.API.Models
{
    public class ProductModel 
    {
        public int Id { get; }
        public string? ProductNumber { get; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

    }
}
