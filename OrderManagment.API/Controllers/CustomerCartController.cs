﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrderManagment.API.Models;
using OrderManagment.Service.Criteria;
using OrderManagment.Service.Dto;
using OrderManagment.Service.Interfaces;

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
        public async Task<IActionResult> CreateOrderAsync(OrderModel orderModel)
        {
            var status = await _orderService.CreateOrUpdateAsync(_mapper.Map<OrderDto>(orderModel));
            return Ok(status);
        }

        [HttpPost]
        [Route("AddItem")]
        public async Task<IActionResult> AddOrderItemAsync(OrderItemModel orderItem)
        {
            var status = await _orderService.CreateOrUpdateAsync(_mapper.Map<OrderItemDto>(orderItem));
            return Ok(status);
        }

        [HttpPut]
        [Route("UpdateItem")]
        public async Task<IActionResult> UpdateOrderItemAsync(OrderItemModel orderItem)
        {
            var status = await _orderService.CreateOrUpdateAsync(_mapper.Map<OrderItemDto>(orderItem));
            return Ok(status);
        }

        [HttpDelete]
        [Route("RemoveItem")]
        public async Task<IActionResult> DeleteOrderItemAsync(int ItemId)
        {
            var status = await _orderService.RemoveAsync(new int[] { ItemId });
            return Ok(status);
        }

        [HttpDelete]
        [Route("RemoveItems")]
        public async Task<IActionResult> DeleteOrderItemsAsync(int[] ItemIds)
        {
            var status = await _orderService.RemoveAsync(ItemIds);
            return Ok(status);
        }

        [HttpPost]
        [Route("CompleteOrder")]
        public async Task<IActionResult> CompleteOrderAsync(OrderModel orderModel)
        {
            var status = await _orderService.CompleteOrderAsync(_mapper.Map<OrderDto>(orderModel));
            return Ok(status);
        }
    }
}
