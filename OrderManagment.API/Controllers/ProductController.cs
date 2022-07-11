using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagment.API.Models;
using OrderManagment.Application.Interfaces.Services;
using OrderManagment.Domain.Critierias;
using OrderManagment.Domain.Entities;

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
        [Route("GetProducts")]
        public async Task<IActionResult> GetProductsAsync([FromQuery] PageModel pageModel)
        {
            var searchCriteria = _mapper.Map<SearchCriteria>(pageModel);
            var results = await _productService.GetProductsAsync(searchCriteria);
            if (results == null || results?.Count() == 0)
            {
                // exceptions are logged using a middleware
                _logger.LogInformation($"Invalid search request {searchCriteria.PageNumber}");
                return Ok(APIResponse.NoContent($"No Product found for pagenumber: {searchCriteria.PageNumber}"));
            }
            return Ok(APIResponse.Success(results));
        }

        [HttpGet]
        [Route("SearchByProductName")]
        public async Task<IActionResult> SearchByProductNameAsync(string productName)
        {
            var results = await _productService.SearchByProductNameAsync(productName);
            if (results == null || results?.Count() == 0)
            {
                // exceptions are logged using a middleware
                _logger.LogInformation($"Invalid search request {productName}");
                return Ok(APIResponse.NoContent($"No Product of {productName} found"));
            }
            return Ok(APIResponse.Success(results));
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<IActionResult> AddAsync(ProductModel productModel)
        {
            var product = _mapper.Map<Product>(productModel);
            var status = await _productService.CreateOrUpdateAsync(product);
            if (status == false)
            {
                return Ok(APIResponse.Error("Failed to add product"));
            }
            return Ok(APIResponse.Created());
        }

        [HttpPut]
        [Route("UpdateProduct")]
        public async Task<IActionResult> UpdateAsync(int productId, ProductModel productModel)
        {
            if (productId > 0)
            {
                var product = _mapper.Map<Product>(productModel);
                product.ProductId = productId;
                var status = await _productService.CreateOrUpdateAsync(product);
                if (status == false)
                {
                    return Ok(APIResponse.Error("Failed to update product"));
                }
                return Ok(APIResponse.Updated());
            }
            return BadRequest(APIResponse.Error($"Invalid productId: {productId}"));
        }

        [HttpDelete]
        [Route("RemoveProduct")]
        public async Task<IActionResult> RemoveAsync(int productId)
        {
            if (productId > 0)
            {
                var status = await _productService.RemoveAsync(new int[] { productId });
                if (status == false)
                {
                    return Ok(APIResponse.Error("Failed to remove product"));
                }
                return Ok(APIResponse.Deleted());
            }
            return BadRequest(APIResponse.Error($"Invalid productId: {productId}"));
        }
    }
}