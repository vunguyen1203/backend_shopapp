using backend_shopapp.Dtos;
using backend_shopapp.Dtos.Variant;
using backend_shopapp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace backend_shopapp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableRateLimiting("fixedwindow")]
    public class VariantController : ControllerBase
    {
        private readonly IVariantService _variantService;

        public VariantController(IVariantService variantService)
        {
            _variantService = variantService;
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPost("{productId}")]
        public async Task<IActionResult> Create([FromRoute] string productId, [FromForm] CreateVariantRequest request)
        {
            await _variantService.Create(productId, request);
            return Created("", new { message = "Create successfully" });
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetAll([FromRoute] string productId, [FromQuery] QueryParameters param)
        {
            var data = await _variantService.GetAll(productId, param);
            return Ok(new
            {
                data,
                param.Page,
                param.Size,
                total = data.Count()
            });
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromForm] UpdateVariantRequest request)
        {
            await _variantService.Update(id, request);
            return Ok(new { message = "Update successfully" });
        }

        [Authorize(Roles = "admin,mod")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _variantService.Delete(id);
            return Ok(new { message = "Delete successfully" });
        }
    }
}
