using AdminPanel.DTO.User;
using Microsoft.AspNetCore.Identity;

namespace AdminPanel.Services.Abstract;

public interface IUserService
{
    Task<ICollection<ReadUser>> GetAllUsersAsync();
    Task<ReadUser> GetUserByIdAsync(int userId);
    Task<IdentityResult> AddUserAsync(WriteUser user);
    Task<IdentityResult> UpdateUserAsync(int userId,UpdateUser user);
    Task<IdentityResult> DeleteUserAsync(int userId);
}