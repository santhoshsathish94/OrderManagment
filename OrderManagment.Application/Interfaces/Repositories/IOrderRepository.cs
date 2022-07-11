using OrderManagment.Domain.Critierias;
using OrderManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<bool> AddOrUpdateItemAsync(OrderItem orderItem);
        Task<bool> DeleteItemsAsync(int[] itemIds);
        Task<IEnumerable<Order>> SearchByOrderNumberAsync(string orderNumber);
        Task<bool> CreateOrderAsync(int customerId);
        Task<bool> CompleteOrderAsync(int billingId);
        Task<IEnumerable<Order>> GetOrdersAsync(SearchCriteria searchCriteria);
    }
}
