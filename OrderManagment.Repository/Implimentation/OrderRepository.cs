using Dapper;
using Microsoft.Extensions.Options;
using OrderManagment.Application.Interfaces.Repositories;
using OrderManagment.Domain.Critierias;
using OrderManagment.Domain.Entities;
using OrderManagment.Domain.Exceptions;
using OrderManagment.Repository.QueryModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Repository.Implimentation
{
    public class OrderRepository : IOrderRepository
    {
        private IDbConnection _orderDatabase
        {
            get
            {
                return new SqlConnection(_dbOptions.OrderDatabase);
            }
        }

        private readonly DatabaseOptions _dbOptions;

        public OrderRepository(IOptions<DatabaseOptions> dbOptions)
        {
            _dbOptions = dbOptions.Value;
        }

        public async Task<bool> AddOrUpdateItemAsync(OrderItem orderItem)
        {
            const string insertSql = @"INSERT INTO [dbo].[OrderItem]
                                                   ([OrderId]
                                                   ,[ProductId]
                                                   ,[UnitPrice]
                                                   ,[Quantity])
                                             VALUES
                                                   (@OrderId
                                                   ,@ProductId
                                                   ,@Price
                                                   ,@Quantity)";
            const string updateSql = @"UPDATE [dbo].[OrderItem]
                                           SET [OrderId] = @OrderId
                                              ,[ProductId] = @ProductId
                                              ,[UnitPrice] = @Price
                                              ,[Quantity] = @Quantity
                                            WHERE Id = @OrderItemId";
            int status = 0;
            if (orderItem == null)
                throw new ArgumentNullException(nameof(orderItem));
            var orderItemId = orderItem?.OrderItemId ?? 0;
            if (orderItemId <= 0)
            {
                status = await _orderDatabase.ExecuteAsync(insertSql, orderItem);
            }
            else
            {
                var existingOrderItem = await GetOrderItemById(orderItemId);
                if (existingOrderItem == null)
                    throw new NotFoundException($"OrderItem Not found {orderItemId}");
                var updateOrderItem = new OrderItem
                {
                    OrderItemId = existingOrderItem.OrderItemId,
                    ProductId = existingOrderItem.ProductId,
                    OrderId = existingOrderItem.OrderId,
                    Price = orderItem.Price <= 0 ? existingOrderItem.Price : orderItem.Price,
                    Quantity = orderItem.Quantity <= 0 ? existingOrderItem.Quantity : orderItem.Quantity
                };
                status = await _orderDatabase.ExecuteAsync(updateSql, updateOrderItem);
            }
            return status == 1;
        }

        private async Task<OrderItem> GetOrderItemById(int orderItemId)
        {
            if (orderItemId <= 0)
                throw new ArgumentNullException(nameof(orderItemId));
            const string sql = @"SELECT  
	                                    Id as OrderItemId,
	                                    ProductId,
                                        OrderId,
	                                    UnitPrice as Price,
	                                    Quantity 
                                FROM OrderItem WHERE Id = @orderItemId";
            return await _orderDatabase.QueryFirstOrDefaultAsync<OrderItem>(sql, new { orderItemId });
        }

        public async Task<bool> DeleteItemsAsync(int[] itemIds)
        {
            const string sql = @"DELETE FROM OrderItem WHERE Id in @itemIds";
            int status = 0;
            if (itemIds == null)
                throw new ArgumentNullException(nameof(itemIds));
            status = await _orderDatabase.ExecuteAsync(sql, new { itemIds });
            return status == 1;
        }

        public async Task<IEnumerable<Order>> SearchByOrderNumberAsync(string orderNumber)
        {
            if (orderNumber == null)
                throw new ArgumentNullException(nameof(orderNumber));
            const string sql = @"SELECT  
	                                o.Id as OrderId,
	                                o.OrderNumber,
	                                o.OrderDate,
	                                o.TotalAmount,
	                                o.BillingId,
	                                o.CustomerId,
	                                oi.Id as OrderItemId,
	                                oi.ProductId,
	                                oi.UnitPrice as Price,
	                                oi.Quantity
                                FROM [Order] o 
                                INNER JOIN [OrderItem] oi on oi.OrderId = o.Id
                                WHERE o.OrderNumber Like '%' + @orderNumber + '%'";
            var results = await _orderDatabase.QueryAsync<QueryOrderModel>(sql, new { orderNumber });

            return ConvertToOrder(results);
        }

        private IEnumerable<Order> ConvertToOrder(IEnumerable<QueryOrderModel> results)
        {
            return (from r in results
                    group r by new
                    {
                        r.OrderId,
                        r.OrderNumber,
                        r.OrderDate,
                        r.BillingId,
                        r.CustomerId,
                        r.TotalAmount
                    } into order
                    select new Order
                    {
                        OrderId = order.Key.OrderId,
                        OrderNumber = order.Key.OrderNumber,
                        OrderDate = order.Key.OrderDate,
                        BillingId = order.Key.BillingId,
                        CustomerId = order.Key.CustomerId,
                        TotalAmount = order.Key.TotalAmount,
                        OrderItems = order.Select(x => new OrderItem
                        {
                            OrderItemId = x.OrderItemId,
                            OrderId = x.OrderId,
                            ProductId = x.ProductId,
                            Price = x.Price,
                            Quantity = x.Quantity,
                        })
                    });
        }

        public Task<bool> CreateOrderAsync(int customerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CompleteOrderAsync(int billingId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(SearchCriteria searchCriteria)
        {
            const string sql = @"SELECT  
	                                o.Id as OrderId,
	                                o.OrderNumber,
	                                o.OrderDate,
	                                o.TotalAmount,
	                                o.BillingId,
	                                o.CustomerId,
	                                oi.Id as OrderItemId,
	                                oi.ProductId,
	                                oi.UnitPrice as Price,
	                                oi.Quantity
                                FROM [Order] o 
                                INNER JOIN [OrderItem] oi on oi.OrderId = o.Id
                                WHERE o.Id In (SELECT Id FROM [Order] ORDER BY Id 
                                OFFSET @OFFSet ROWS 
                                FETCH NEXT @PageSize ROWS ONLY);";
            var results = await _orderDatabase.QueryAsync<QueryOrderModel>(sql, searchCriteria );

            return ConvertToOrder(results);
        }
    }
}
