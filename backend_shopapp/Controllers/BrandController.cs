using backend_shopapp.Dtos.Brand;
using backend_shopapp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace backend_shopapp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableRateLimiting("fixedwindow")]
    public class BrandController : ControllerBase
    {
        private readonly IService<CreateBrandRequest, UpdateBrandRequest, BrandResponse> _brandService;

        public BrandController(IService<CreateBrandRequest, UpdateBrandRequest, BrandResponse> brandServicer)
        {
            _brandService = brandServicer;
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBrandRequest request)
        {
            await _brandService.Create(request);
            return Created("", new { message = "Create successfully" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _brandService.GetAll(null));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return Ok(await _brandService.GetById(id));
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromForm] UpdateBrandRequest request)
        {
            await _brandService.Update(id, request);
            return Ok(new { message = "Update successfully" });
        }

        [Authorize(Roles = "admin,mod")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _brandService.Delete(id);
            return Ok(new { message = "Delete successfully" });
        }
    }
}

