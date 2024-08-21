using AdminPanel.Data;
using AdminPanel.DTO.User;
using AdminPanel.Entities;
using AdminPanel.Repositories.Abstract.User;
using AdminPanel.Services.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AdminPanel.Services.Concrete;

public class UserService: IUserService
{
    private readonly AdminPanelDB _context;
    private readonly UserManager<User> _userManager;


    public UserService(AdminPanelDB context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<ICollection<ReadUser>> GetAllUsersAsync()
    {
        var rawUsers = await _context.Users.ToListAsync();

        var readUserDto = rawUsers.Select(u => new ReadUser()
        {
            Id = u.Id,
            Firstname = u.Firstname,
            Lastname = u.Lastname,
            Email = u.Email
        }).ToList();

        return readUserDto;
    }

    public async Task<ReadUser> GetUserByIdAsync(int userId)
    {
        var rawUser = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (rawUser is not null)
        {
            var readuserDto = new ReadUser()
            {
                Id = rawUser.Id,
                Firstname = rawUser.Firstname,
                Lastname = rawUser.Lastname,
                Email = rawUser.Email
            };

            return readuserDto;
        }

        return null;
    }

    public async Task<IdentityResult> AddUserAsync(WriteUser user)
    {
        var newUser = new User()
        {
            Firstname = user.Firstname,
            Lastname = user.Lastname,
            Email = user.Email,
            UserName = user.Username
        };
        
        var result = await _userManager.CreateAsync(newUser,user.Password);

        if (result.Succeeded)
        {
            var roleResult = await _userManager.AddToRoleAsync(newUser, user.Role);
            
            if (!roleResult.Succeeded)
            {
                return roleResult;
            }
        }

        return result;
    }

    public async Task<IdentityResult> UpdateUserAsync(int userId, UpdateUser writeUser)
    {
        // Retrieve the user from the database
        var user = await _userManager.FindByIdAsync(userId.ToString());
        
        if (user is null) return IdentityResult.Failed(new IdentityError { Description = "User not found." });

        // Update user properties
        if (user.Firstname != writeUser.Firstname)
            user.Firstname = writeUser.Firstname;

        if (user.Lastname != writeUser.Lastname)
            user.Lastname = writeUser.Lastname;

        if (user.Email != writeUser.Email)
            user.Email = writeUser.Email;

        if (user.UserName != writeUser.Username)
            user.UserName = writeUser.Username;
        
        // Update the user information
        var updateResult = await _userManager.UpdateAsync(user);

        return updateResult;
    }

    public async Task<IdentityResult> DeleteUserAsync(int userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        
        if (user == null)
        {
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });
        }

        // Delete the user
        var result = await _userManager.DeleteAsync(user);

        return result;

    }
}