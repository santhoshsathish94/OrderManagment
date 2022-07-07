using AutoMapper;
using OrderManagment.Repository.Interface;
using OrderManagment.Service.Criteria;
using OrderManagment.Service.Dto;
using OrderManagment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagment.Service.Implimentations
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
        public Task<bool> CreateOrUpdateAsync(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveAsync(int[] Ids)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductDto>> SearchByProductNameAsync(string productName)
        {
            var products = await _productRepository.SearchByProductNameAsync(productName);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
