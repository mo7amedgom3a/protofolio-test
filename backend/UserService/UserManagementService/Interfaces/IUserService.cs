using UserManagementService.DTOs;
using UserManagementService.Models;

namespace UserManagementService.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        Task CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(string id, UserProfileUpdateDto updatedUser);
        Task<bool> DeleteUserAsync(string id);
        Task<bool> FollowUserAsync(string userId, string targetId);
        Task<bool> UnfollowUserAsync(string userId, string targetId);
        Task<List<User>> GetFollowersAsync(string userId);
        Task<List<User>> GetFollowingAsync(string userId);
    }
}
