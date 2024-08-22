using AdminPanel.DTO.Auth;
using AdminPanel.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers;

[Route("api/[controller]")] 
[ApiController]
public class AccountController: ControllerBase
{
    private readonly IAuthService _authService;

    public AccountController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var result = await _authService.Register(registerDto);

        if (result.Succeeded)
        {
            return Ok(new { Message = "Registration successful" });
        }

        var errors = result.Errors.Select(e => e.Description).ToList();
        return BadRequest(new { Message = "Registration failed", Errors = errors });
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var (signInResult, token) = await _authService.Login(loginDto);
    
        if (!signInResult.Succeeded)
        {
            return Unauthorized(new { Message = "Invalid username or password" });
        }
    
        return Ok(new { Token = token, Message = "Login successful" });
    }
    
}