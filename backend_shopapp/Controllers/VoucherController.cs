using backend_shopapp.Dtos;
using backend_shopapp.Dtos.Voucher;
using backend_shopapp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace backend_shopapp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableRateLimiting("fixedwindow")]
    public class VoucherController : ControllerBase
    {
        private readonly IService<CreateVoucherRequest, UpdateVoucherRequest, VoucherResponse> _voucherService;

        public VoucherController(IService<CreateVoucherRequest, UpdateVoucherRequest, VoucherResponse> voucherService)
        {
            _voucherService = voucherService;
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVoucherRequest request)
        {
            await _voucherService.Create(request);
            return Created("", new { message = "Create successfully" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryParameters param)
        {
            return Ok(await _voucherService.GetAll(param));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return Ok(await _voucherService.GetById(id));
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateVoucherRequest request)
        {
            await _voucherService.Update(id, request);
            return Ok(new { message = "Update successfully" });
        }

        [Authorize(Roles = "admin,mod")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _voucherService.Delete(id);
            return Ok(new { message = "Delete successfully" });
        }
    }
}
