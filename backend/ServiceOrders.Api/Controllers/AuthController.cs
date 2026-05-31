using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceOrders.Application.DTOs.Auth;
using ServiceOrders.Application.Interfaces;

namespace ServiceOrders.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
    LoginRequestDto request)
    {
        var result = await _service.LoginAsync(request);

        if (result is null)
            return Unauthorized();

        return Ok(result);
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        var username = User.Identity?.Name;

        var user =
        await _service.GetCurrentUserAsync(username!);

        return Ok(user);
    }
}