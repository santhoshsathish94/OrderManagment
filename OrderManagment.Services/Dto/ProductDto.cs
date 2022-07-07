using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Service.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string? ProductName { get; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
