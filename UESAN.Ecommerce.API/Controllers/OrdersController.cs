using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UESAN.Ecommerce.CORE.Core.DTOs;
using UESAN.Ecommerce.CORE.Core.Interfaces;

namespace UESAN.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrdersDTO orderDto)
        {
            if (orderDto == null || orderDto.OrderDetails == null || orderDto.OrderDetails.Count == 0)
                return BadRequest("Order or details are missing");
            var newOrderId = await _ordersService.CreateOrderAsync(orderDto);
            return Ok(newOrderId);
        }
    }
}
