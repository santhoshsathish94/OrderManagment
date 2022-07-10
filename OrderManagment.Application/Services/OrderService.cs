using OrderManagment.Application.Interfaces.Services;
using OrderManagment.Domain.Entities;

namespace OrderManagment.Application.Services
{
    public class OrderService : IOrderService
    {
        public OrderService()
        {
        }

        public Task<bool> CompleteOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateOrderAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateOrUpdateItemAsync(OrderItem orderItem)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveItemAsync(int[] Ids)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> SearchByOrderNumberAsync(string orderNumber)
        {
            throw new NotImplementedException();
        }
    }
}
