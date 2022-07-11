using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagment.API.Models;
using OrderManagment.Application.Interfaces.Services;
using OrderManagment.Domain.Critierias;
using OrderManagment.Domain.Entities;

namespace OrderManagment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerCartController : ControllerBase
    {

        private readonly ILogger<CustomerCartController> _logger;
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public CustomerCartController(ILogger<CustomerCartController> logger, IOrderService orderService,
            IMapper mapper)
        {
            _logger = logger;
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<IActionResult> GetOrdersAsync([FromQuery] PageModel pageModel)
        {
            var searchCriteria = _mapper.Map<SearchCriteria>(pageModel);
            var results = await _orderService.GetOrdersAsync(searchCriteria);
            if (results == null || results?.Count() == 0)
            {
                // exceptions are logged using a middleware
                _logger.LogInformation($"Invalid search request {searchCriteria.PageNumber}");
                return Ok(APIResponse.NoContent($"No Orders found for pagenumber: {searchCriteria.PageNumber}"));
            }
            return Ok(APIResponse.Success(results));
        }

        [HttpGet]
        [Route("SearchByOrderNumber")]
        public async Task<IActionResult> SearchByOrderNumberAsync(string orderNumber)
        {
            var results = await _orderService.SearchByOrderNumberAsync(orderNumber);
            if (results == null || results?.Count() == 0)
            {
                // exceptions are logged using a middleware
                _logger.LogInformation($"Invalid search request {orderNumber}");
                return Ok(APIResponse.NoContent($"No Order of {orderNumber} found"));
            }
            return Ok(APIResponse.Success(results));
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrderAsync(int customerId)
        {
            if (customerId > 0)
            {
                var status = await _orderService.CreateOrderAsync(customerId);
                if (status == false)
                {
                    return Ok(APIResponse.Error("Failed to create order"));
                }
                return Ok(APIResponse.Created());
            }
            return BadRequest(APIResponse.Error($"Invalid customerId: {customerId}"));
            
        }

        [HttpPost]
        [Route("AddItem")]
        public async Task<IActionResult> AddOrderItemAsync(OrderItemModel orderItemModel)
        {
            var orderItem = _mapper.Map<OrderItem>(orderItemModel);
            var status = await _orderService.CreateOrUpdateItemAsync(orderItem);
            if (status == false)
            {
                return Ok(APIResponse.Error("Failed to add orderItem"));
            }
            return Ok(APIResponse.Created());
        }

        [HttpPut]
        [Route("UpdateItem")]
        public async Task<IActionResult> UpdateOrderItemAsync(int orderItemId, OrderItemUpdateModel orderItemModel)
        {
            if (orderItemId > 0)
            {
                var orderItem = _mapper.Map<OrderItem>(orderItemModel);
                orderItem.OrderItemId = orderItemId;
                var status = await _orderService.CreateOrUpdateItemAsync(orderItem);
                if (status == false)
                {
                    return Ok(APIResponse.Error("Failed to update orderitem"));
                }
                return Ok(APIResponse.Updated());
            }
            return BadRequest(APIResponse.Error($"Invalid orderItemId: {orderItemId}"));
        }

        [HttpDelete]
        [Route("RemoveItem")]
        public async Task<IActionResult> DeleteOrderItemAsync(int itemId)
        {
            if (itemId > 0)
            {
                var status = await _orderService.RemoveItemAsync(new int[] { itemId });
                if (status == false)
                {
                    return Ok(APIResponse.Error("Failed to remove OrderItem"));
                }
                return Ok(APIResponse.Deleted());
            }
            return BadRequest(APIResponse.Error($"Invalid itemId: {itemId}"));
        }     

        [HttpPost]
        [Route("CompleteOrder")]
        public async Task<IActionResult> CompleteOrderAsync(int billingId)
        {
            if (billingId > 0)
            {
                var status = await _orderService.CompleteOrderAsync(billingId);
                if (status == false)
                {
                    return Ok(APIResponse.Error("Failed to complete order"));
                }
                return Ok(APIResponse.Created());
            }
            return BadRequest(APIResponse.Error($"Invalid billingId: {billingId}"));
        }
    }
}
