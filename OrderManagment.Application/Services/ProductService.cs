using AutoMapper;
using OrderManagment.Application.Interfaces.Repositories;
using OrderManagment.Application.Interfaces.Services;
using OrderManagment.Domain.Entities;

namespace OrderManagment.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<bool> CreateOrUpdateAsync(Product product)
        {
            return await _productRepository.AddOrUpdateAsync(product);
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
