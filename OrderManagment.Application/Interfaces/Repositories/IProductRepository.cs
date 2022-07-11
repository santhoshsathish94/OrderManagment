using OrderManagment.Domain.Critierias;
using OrderManagment.Domain.Entities;

namespace OrderManagment.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> SearchByProductNameAsync(string productName);
        Task<bool> AddOrUpdateAsync(Product product);
        Task<bool> DeleteAsync(int[] ids);
        Task<IEnumerable<Product>> GetProductsAsync(SearchCriteria searchCriteria);
    }
}
