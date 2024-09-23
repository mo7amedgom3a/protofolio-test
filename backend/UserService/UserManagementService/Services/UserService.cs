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
    }
}
