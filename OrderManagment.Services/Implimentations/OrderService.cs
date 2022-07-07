using OrderManagment.Service.Criteria;
using OrderManagment.Service.Dto;
using OrderManagment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Service.Implimentations
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {
        }

        public Task<bool> CompleteOrderAsync(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateOrUpdateAsync(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateOrUpdateAsync(OrderItemDto orderItemDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int[] Ids)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDto>> SearchByOrderNumberAsync(string orderNumber)
        {
            throw new NotImplementedException();
        }
    }
}
