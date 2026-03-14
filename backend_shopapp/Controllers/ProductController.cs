using backend_shopapp.Dtos;
using backend_shopapp.Dtos.Product;
using backend_shopapp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace backend_shopapp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableRateLimiting("fixedwindow")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateProductRequest request)
        {
            string productId = await _productService.Create(request);
            return Created("", new { message = "Create successfully", productId });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductQueryParameters param)
        {
            var data = await _productService.GetAll(param);
            return Ok(new
            {
                data,
                param.Page,
                param.Size,
                total = data.Count()
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            return Ok(await _productService.GetById(id));
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateProductRequest request)
        {
            await _productService.Update(id, request);
            return Ok(new { message = "Update successfully" });
        }

        [Authorize(Roles = "admin,mod")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _productService.Delete(id);
            return Ok(new { message = "Delete successfully" });
        }
    }
}
