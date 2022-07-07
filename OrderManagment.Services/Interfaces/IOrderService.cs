using OrderManagment.Service.Criteria;
using OrderManagment.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> SearchByOrderNumberAsync(string orderNumber);
        Task<bool> CreateOrUpdateAsync(OrderDto orderDto);
        Task<bool> CreateOrUpdateAsync(OrderItemDto orderItemDto);
        Task<bool> RemoveAsync(int[] Ids);
        Task<bool> CompleteOrderAsync(OrderDto orderDto);
    }
}
