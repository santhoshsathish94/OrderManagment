using OrderManagment.Application.Interfaces.Repositories;
using OrderManagment.Application.Interfaces.Services;
using OrderManagment.Domain.Critierias;
using OrderManagment.Domain.Entities;

namespace OrderManagment.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<bool> CreateOrUpdateAsync(Product product)
        {
            return await _productRepository.AddOrUpdateAsync(product);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(SearchCriteria searchCriteria)
        {
            return await _productRepository.GetProductsAsync(searchCriteria);
        }

        public async Task<bool> RemoveAsync(int[] Ids)
        {
            return await _productRepository.DeleteAsync(Ids);
        }

        public async Task<IEnumerable<Product>> SearchByProductNameAsync(string productName)
        {
            return await _productRepository.SearchByProductNameAsync(productName);
        }
    }
}
