using UserManagementService.Models;
using UserManagementService.DTOs;
namespace UserManagementService.Interfaces
{
    public interface IUserRepository
    {
        Task<IList<User>> GetUsers();
        Task<User> GetUser(string id);
        Task<User> CreateUser(User user);
        Task<bool> UpdateUser(string id, UserProfileUpdateDto user);
        Task<bool> DeleteUser(string id);
        Task<bool> FollowUser(string userId, string targetId);
        Task<bool> UnfollowUser(string userId, string targetId);

        Task<List<User>> GetFollowers(string userId);
        Task<List<User>> GetFollowing(string userId);
    }
}