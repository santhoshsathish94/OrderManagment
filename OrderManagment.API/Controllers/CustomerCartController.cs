using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagment.API.Models;
using OrderManagment.Application.Interfaces.Services;
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
        [Route("SearchByOrderNumber")]
        public async Task<IActionResult> SearchByOrderNumberAsync(string orderNumber)
        {
            var results = await _orderService.SearchByOrderNumberAsync(orderNumber);
            return Ok(results);
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<IActionResult> CreateOrderAsync(int customerId)
        {
            var status = await _orderService.CreateOrderAsync(customerId);
            return Ok(status);
        }

        [HttpPost]
        [Route("AddItem")]
        public async Task<IActionResult> AddOrderItemAsync(OrderItemModel orderItem)
        {
            var model = _mapper.Map<OrderItem>(orderItem);
            var status = await _orderService.CreateOrUpdateItemAsync(model);
            return Ok(status);
        }

        [HttpPut]
        [Route("UpdateItem")]
        public async Task<IActionResult> UpdateOrderItemAsync(OrderItemModel orderItem)
        {
            var model = _mapper.Map<OrderItem>(orderItem);
            var status = await _orderService.CreateOrUpdateItemAsync(model);
            return Ok(status);
        }

        [HttpDelete]
        [Route("RemoveItem")]
        public async Task<IActionResult> DeleteOrderItemAsync(int ItemId)
        {
            var status = await _orderService.RemoveItemAsync(new int[] { ItemId });
            return Ok(status);
        }

        [HttpDelete]
        [Route("RemoveItems")]
        public async Task<IActionResult> DeleteOrderItemsAsync(int[] ItemIds)
        {
            var status = await _orderService.RemoveItemAsync(ItemIds);
            return Ok(status);
        }

        [HttpPost]
        [Route("CompleteOrder")]
        public async Task<IActionResult> CompleteOrderAsync(Order order)
        {
            var status = await _orderService.CompleteOrderAsync(order);
            return Ok(status);
        }
    }
}
