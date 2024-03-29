﻿using OrderManagment.Domain.Critierias;
using OrderManagment.Domain.Entities;

namespace OrderManagment.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> SearchByOrderNumberAsync(string orderNumber);
        Task<bool> CreateOrderAsync(int customerId);
        Task<bool> CreateOrUpdateItemAsync(OrderItem orderItem);
        Task<bool> RemoveItemAsync(int[] Ids);
        Task<bool> CompleteOrderAsync(int billingId);
        Task<IEnumerable<Order>> GetOrdersAsync(SearchCriteria searchCriteria);
    }
}
