using backend_shopapp.Dtos;
using backend_shopapp.Dtos.Order;
using backend_shopapp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Security.Claims;

namespace backend_shopapp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableRateLimiting("fixedwindow")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderRequest request)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string orderId = await _orderService.Create(userId, request);
            return Created("", new { message = "Create successfully", orderId });
        }

        [Authorize(Roles = "admin,mod")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] OrderQueryParameters param)
        {
            var orders = await _orderService.GetAll(param, null);
            return Ok(new
            {
                data = orders,
                param.Page,
                param.Size,
                total = orders.Count()
            });
        }

        [Authorize]
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrent([FromQuery] OrderQueryParameters param)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var orders = await _orderService.GetAll(param, userId);
            return Ok(new
            {
                data = orders,
                param.Page,
                param.Size,
                total = orders.Count()
            });
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return Ok(await _orderService.GetById(id));
        }

        [Authorize]
        [HttpPut("{id}/confirm-order")]
        public async Task<IActionResult> ConfirmOrderCodPayment([FromRoute] string id, [FromBody] ConfirmOrderRequest request)
        {
            await _orderService.ConfirmOrderSuccess(id);
            return Ok(new { message = "Confirm successfully" });
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPut("{orderCode}")]
        public async Task<IActionResult> SetShipping([FromRoute] string orderCode)
        {
            await _orderService.SetShipping(orderCode);
            return Ok(new { message = "Set shipping successfully" });
        }

        [Authorize]
        [HttpPut("{id}/info")]
        public async Task<IActionResult> UpdateInfo([FromRoute] string id,[FromBody] UpdateOrderRequest request)
        {
            await _orderService.UpdateInfo(id, request);
            return Ok(new { message = "Update successfully" });
        }

        [Authorize]
        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> Cancel([FromRoute] string id)
        {
            await _orderService.CancellOrder(id);
            return Ok(new { message = "Cancel order successfully" });
        }
    }
}
