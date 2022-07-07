using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Service.Dto
{
    public class OrderDto
    {
        public Guid Id { get; }
        public string? OrderNumber { get; }
        public int CustomerId { get; set; }
        public IEnumerable<OrderItemDto> OrderItems { get; set; } = Enumerable.Empty<OrderItemDto>();
    }

}
