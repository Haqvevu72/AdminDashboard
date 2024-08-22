using AdminPanel.DTO.Auth;
using AdminPanel.Entities;
using AdminPanel.Services.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace AdminPanel.Services.Concrete;

public class AuthService: IAuthService
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<User> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task<IdentityResult> Register(RegisterDto registerDto)
    {
        var user = new User { UserName = registerDto.UserName, Email = registerDto.Email };
        var result = await _userManager.CreateAsync(user, registerDto.Password);

        return result;
    }
    
    public async Task<(SignInResult, string)> Login(LoginDto loginDto)
    {
        var user = await _userManager.FindByNameAsync(loginDto.UserName);
        if (user == null)
        {
            return (SignInResult.Failed, null);
        }

        var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
        if (!result)
        {
            return (SignInResult.Failed, null);
        }

        var token = await _tokenService.GenerateJwtToken(user);
        return (SignInResult.Success, token);
    }


}