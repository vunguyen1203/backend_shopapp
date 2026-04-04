using backend_shopapp.Dtos;
using backend_shopapp.Dtos.User;
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
    public class UserController : ControllerBase
    {   
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserRequest request)
        {
            await _userService.Create(request);
            return Created("", new { message = "Register successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            (string accessToken, string refreshToken) = await _userService.Login(request);

            return Ok(new { message = "Login successfully", accessToken , refreshToken});
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromQuery] string refreshToken)
        {
            string? id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _userService.Logout(id, refreshToken);

            return Ok(new { message = "Logout successfully" });
        }

        [Authorize]
        [HttpPost("logout-all")]
        public async Task<IActionResult> LogoutAll()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _userService.LogoutAll(userId);

            return Ok(new { message = "Logout successfully" });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            await _userService.ForgotPassword(request);
            return Ok(new { message = "The password reset code has been sent to your email" });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            await _userService.ResetPassword(request);
            return Ok(new { message = "Reset passowrd successfully" });
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromQuery] string refreshToken)
        {
            if (string.IsNullOrWhiteSpace(refreshToken)) return Unauthorized("No token");
            string accessToken = await _userService.RefreshToken(refreshToken);

            return Ok(new { accessToken });
        }

        [Authorize(Roles = "admin,mod")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryParameters param)
        {
            var data = await _userService.GetAll(param);
            return Ok(new
            {
                data,
                param.Page,
                param.Size,
                total = data.Count()
            });
        }

        [Authorize(Roles = "admin,mod")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByAdmin([FromRoute] string id)
        {
            return Ok(await _userService.GetById(id));
        }

        [Authorize]
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrent()
        {
            string? id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _userService.GetById(id));
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPut("current")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
        {
            string? id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _userService.Update(id, request);
            return Ok(new { message = "Update successfully" });
        }

        [Authorize(Roles = "admin,mod")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateByAdmin([FromRoute] string id, [FromBody] UpdateUserByAdminRequest request)
        {
            string? currentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string? currentRole = User.FindFirst(ClaimTypes.Role)?.Value;
            await _userService.UpdateByAdmin(currentId, currentRole, id, request);
            return Ok(new { message = "Update successfully" });
        }

        [Authorize(Roles = "admin,mod")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            string? currentId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            string? currentRole = User.FindFirst(ClaimTypes.Role)?.Value;
            await _userService.Delete(currentId, currentRole, id);
            return Ok(new { message = "Delete successfully" });
        }
    }
}