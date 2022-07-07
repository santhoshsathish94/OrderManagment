using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagment.API.Models;
using OrderManagment.Service.Criteria;
using OrderManagment.Service.Dto;
using OrderManagment.Service.Interfaces;

namespace OrderManagment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger, IProductService productService,
            IMapper mapper)
        {
            _logger = logger;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("SearchByProductName")]
        public async Task<IActionResult> SearchByProductNameAsync(string productName)
        {
            var results = await _productService.SearchByProductNameAsync(productName);
            return Ok(APIResponse.Success(results));
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddAsync(ProductModel productModel)
        {
            var status = await _productService.CreateOrUpdateAsync(_mapper.Map<ProductDto>(productModel));
            return Ok(status);
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateAsync(ProductModel productModel)
        {
            var status = await _productService.CreateOrUpdateAsync(_mapper.Map<ProductDto>(productModel));
            return Ok(status);
        }

        [HttpDelete]
        [Route("RemoveProduct")]
        public async Task<IActionResult> RemoveAsync(int productId)
        {
            var status = await _productService.RemoveAsync(new int[] { productId });
            return Ok(status);
        }
    }
}