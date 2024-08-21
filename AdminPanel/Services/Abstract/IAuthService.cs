using AdminPanel.DTO.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace AdminPanel.Services.Abstract;

public interface IAuthService
{
    public Task<IdentityResult> Register([FromBody] RegisterDto registerDto);
    public Task<(SignInResult, string)> Login([FromBody] LoginDto loginDto);
}