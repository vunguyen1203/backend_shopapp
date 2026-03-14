using backend_shopapp.Dtos;
using backend_shopapp.Dtos.FeedBack;
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
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBackService _feedBackService;

        public FeedBackController(IFeedBackService feedBackService)
        {
            _feedBackService = feedBackService;
        }

        [Authorize]
        [HttpPost("{productId}")]
        public async Task<IActionResult> FeedBack([FromRoute] string productId,[FromBody] CreateFeedBackRequest request)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _feedBackService.FeedBack(userId, productId, request);
            return Created("", new { message = "FeedBack successfully" });
        }

        [Authorize]
        [HttpPost("replay/{parentId}")]
        public async Task<IActionResult> ReplayFeedBack(
            [FromRoute] string parentId, 
            [FromBody] ReplayFeedBackRequest request)
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _feedBackService.ReplayFeedBack(userId, parentId, request);
            return Created("", new { message = "Replay successfully" });
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByProduct([FromRoute] string productId,[FromQuery] QueryParameters param)
        {
            var feedBacks = await _feedBackService.GetAll(productId, param);
            return Ok(new
            {
                data = feedBacks,
                param.Page,
                param.Size,
                total = feedBacks.Count(),
            });
        }
    }
}
