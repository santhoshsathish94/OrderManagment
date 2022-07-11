using OrderManagment.Application.Interfaces.Repositories;
using OrderManagment.Application.Interfaces.Services;
using OrderManagment.Domain.Critierias;
using OrderManagment.Domain.Entities;

namespace OrderManagment.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<bool> CompleteOrderAsync(int billingId)
        {
            return await _orderRepository.CompleteOrderAsync(billingId);
        }

        public async Task<bool> CreateOrderAsync(int customerId)
        {
            return await _orderRepository.CreateOrderAsync(customerId);
        }

        public async Task<bool> CreateOrUpdateItemAsync(OrderItem orderItem)
        {
            return await _orderRepository.AddOrUpdateItemAsync(orderItem);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(SearchCriteria searchCriteria)
        {
            return await _orderRepository.GetOrdersAsync(searchCriteria);
        }

        public async Task<bool> RemoveItemAsync(int[] itemIds)
        {
            return await _orderRepository.DeleteItemsAsync(itemIds);
        }

        public async Task<IEnumerable<Order>> SearchByOrderNumberAsync(string orderNumber)
        {
            return await _orderRepository.SearchByOrderNumberAsync(orderNumber);
        }
    }
}
