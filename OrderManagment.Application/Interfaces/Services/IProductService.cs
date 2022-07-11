using OrderManagment.Domain.Critierias;
using OrderManagment.Domain.Entities;

namespace OrderManagment.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<bool> CreateOrUpdateAsync(Product product);
        Task<bool> RemoveAsync(int[] Ids);
        Task<IEnumerable<Product>> SearchByProductNameAsync(string productName);
        Task<IEnumerable<Product>> GetProductsAsync(SearchCriteria searchCriteria);
    }
}
