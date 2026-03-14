using backend_shopapp.Dtos.Category;
using backend_shopapp.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace backend_shopapp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [EnableRateLimiting("fixedwindow")]
    public class CategoryController : ControllerBase
    {
        private readonly IService<CreateCategoryRequest, UpdateCategoryRequest, CategoryResponse> _categoryService;
        public CategoryController(IService<CreateCategoryRequest, UpdateCategoryRequest, CategoryResponse> categoryService)
        {
            _categoryService = categoryService;
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
        {
            await _categoryService.Create(request);
            return Created("", new { message = "Create successfully" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAll(null));   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            return Ok(await _categoryService.GetById(id));
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] string id, [FromBody] UpdateCategoryRequest request)
        {
            await _categoryService.Update(id, request);
            return Ok(new { message = "Update successfully" });
        }

        [Authorize(Roles = "admin,mod")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            await _categoryService.Delete(id);
            return Ok(new { message = "Delete successfully" });
        }
    }
}
