using AdminPanel.DTO.User;
using AdminPanel.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AdminPanel.Controllers;

[Route("api/[controller]")] 
[ApiController]

public class UserController: ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("GetAllUsers")]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var result = await _userService.GetAllUsersAsync();
        return Ok(result);
    }

    [HttpGet("GetUserById")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var result = await _userService.GetUserByIdAsync(userId);

        if (result is not null) return Ok(result);
        
        return NotFound();
    }

    [HttpPost("AddUser")]
    public async Task<IActionResult> AddUser(WriteUser writeUser)
    {
        var result = await _userService.AddUserAsync(writeUser);

        if (result.Succeeded)
        {
            return Ok("User is added successfully .");
        }

        return BadRequest(result.Errors);
    }

    [HttpPost("UpdateUser")]
    public async Task<IActionResult> UpdateUser(int userId,UpdateUser updateUser)
    {
        var result = await _userService.UpdateUserAsync(userId,updateUser);

        if (result.Succeeded)
        {
            return Ok("User updateed successfully. ");
        }

        return BadRequest(result.Errors);
    }

    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser(int userId)
    {
        var result = await _userService.DeleteUserAsync(userId);

        if (result.Succeeded)
        {
            return Ok("User deleted successfully.");
        }

        return BadRequest(result.Errors);
    }
}