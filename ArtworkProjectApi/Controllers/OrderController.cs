using ArtworkProjectApi.DTOs;
using ArtworkProjectApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArtworkProjectApi.Controllers
{
    [ApiController]
    [Route("store/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDto orderDto)
        {
            var result = await _orderService.CreateOrderAsync(orderDto);
            return CreatedAtAction(nameof(GetAllOrders), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrderAsync();
            return Ok(orders);
        }
    }
}
