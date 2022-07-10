using Dapper;
using Microsoft.Extensions.Options;
using OrderManagment.Application.Interfaces.Repositories;
using OrderManagment.Domain.Entities;
using System.Data;
using System.Data.SqlClient;

namespace OrderManagment.Repository.Implimentation
{
    public class ProductRepository : IProductRepository
    {
        private IDbConnection _orderDatabase
        {
            get
            {
                return new SqlConnection(_dbOptions.OrderDatabase);
            }
        }

        private readonly DatabaseOptions _dbOptions;

        public ProductRepository(IOptions<DatabaseOptions> dbOptions)
        {
            _dbOptions = dbOptions.Value;
        }

        public async Task<IEnumerable<Product>> SearchByProductNameAsync(string productName)
        {
            if (productName == null)
                throw new ArgumentNullException(nameof(productName));
            const string sql = @"SELECT  
	                                    Id as ProductId,
	                                    ProductName,
	                                    ProductDiscription,
	                                    UnitPrice as Price,
	                                    Quantity 
                                FROM Product WHERE ProductName Like '%' + @productName + '%'";
            return await _orderDatabase.QueryAsync<Product>(sql, new { productName });
        }

        public async Task<bool> AddOrUpdateAsync(Product product)
        {
            const string insertSql = @"INSERT INTO [dbo].[Product]
                                                   ([ProductName]
                                                   ,[ProductDiscription]
                                                   ,[UnitPrice]
                                                   ,[Quantity])
                                             VALUES
                                                   (@ProductName
                                                   ,@ProductDiscription
                                                   ,@Price
                                                   ,@Quantity)";
            const string updateSql = @"UPDATE [dbo].[Product]
                                            SET [ProductName] = @ProductName
                                                ,[ProductDiscription] = @ProductDiscription
                                                ,[UnitPrice] = @Price
                                                ,[Quantity] = @Quantity
                                            WHERE Id = @ProductId";
            int status = 0;
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            var productId = product?.ProductId ?? 0;
            if (productId <= 0)
            {
                status = await _orderDatabase.ExecuteAsync(insertSql, product);
            }
            else
            {
                var existingProduct = await GetProductById(productId);
                if (existingProduct == null)
                    throw new ArgumentException($"Product Not found {productId}");
                var updateProduct = new Product
                {
                    ProductId = existingProduct.ProductId,
                    ProductName = product.ProductName == String.Empty ?
                        existingProduct.ProductName : product.ProductName,
                    ProductDiscription = (product.ProductDiscription ?? String.Empty) == String.Empty ?
                        existingProduct.ProductDiscription : product.ProductDiscription,
                    Price = product.Price <= 0 ? existingProduct.Price : product.Price,
                    Quantity = product.Quantity <= 0 ? existingProduct.Quantity : product.Quantity
                };
                status = await _orderDatabase.ExecuteAsync(updateSql, updateProduct);
            }
            return status == 1;
        }

        private async Task<Product> GetProductById(int productId)
        {
            if (productId <= 0)
                throw new ArgumentNullException(nameof(productId));
            const string sql = @"SELECT  
	                                    Id as ProductId,
	                                    ProductName,
	                                    ProductDiscription,
	                                    UnitPrice as Price,
	                                    Quantity 
                                FROM Product WHERE Id = @productId";
            return await _orderDatabase.QueryFirstOrDefaultAsync<Product>(sql, new { productId });
        }

        public async Task<bool> DeleteAsync(int[] productIds)
        {
            const string sql = @"DELETE FROM Product WHERE Id in @productIds";
            int status = 0;
            if (productIds == null)
                throw new ArgumentNullException(nameof(productIds));
            status = await _orderDatabase.ExecuteAsync(sql, new { productIds });
            return status == 1;
        }
    }
}