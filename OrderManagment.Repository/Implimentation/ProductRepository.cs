using Dapper;
using Microsoft.Extensions.Options;
using OrderManagment.Repository.Entities;
using OrderManagment.Repository.Interface;
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
            const string sql = @"SELECT * FROM Product WHERE ProductName Like '%@productName%'";
            return await _orderDatabase.QueryAsync<Product>(sql, productName);
        }


    }
}