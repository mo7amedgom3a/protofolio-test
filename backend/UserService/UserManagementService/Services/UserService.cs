using MongoDB.Driver;
using UserManagementService.Interfaces;
using UserManagementService.Models;
using UserManagementService.Repositories;
using UserManagementService.DTOs;

namespace UserManagementService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateUser(user);
        }

        public async Task<bool> UpdateUserAsync(string id, UserProfileUpdateDto updatedUser)
        {
            return await _userRepository.UpdateUser(id, updatedUser);
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<bool> FollowUserAsync(string userId, string targetId)
        {
            return await _userRepository.FollowUser(userId, targetId);
        }
        public async Task<bool> UnfollowUserAsync(string userId, string targetId)
        {
            return await _userRepository.UnfollowUser(userId, targetId);
        }
        public async Task<List<User>> GetFollowersAsync(string userId)
        {
            return await _userRepository.GetFollowers(userId);
        }
        public async Task<List<User>> GetFollowingAsync(string userId)
        {
            return await _userRepository.GetFollowing(userId);
        }
    }
}
