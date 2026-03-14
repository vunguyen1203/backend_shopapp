using backend_shopapp.Dtos.Payment;
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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreatePaymentRequest request)
        {
            string userName = User.FindFirst(ClaimTypes.Name)?.Value;
            string result = await _paymentService.CreatePayment(request, HttpContext, userName);
            return Ok(new { message = "Create successfully", result });
        }

        [HttpGet("vnpay-return")]
        public async Task<IActionResult> VnPayReturn()
        {
            await _paymentService.VnPayReturn(Request.Query);
            return Ok(new { message = "Payment successfully" });
        }
    }
}
