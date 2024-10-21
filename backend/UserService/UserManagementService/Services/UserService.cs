using MongoDB.Driver;
using UserManagementService.Interfaces;
using UserManagementService.Models;
using UserManagementService.Repositories;
using UserManagementService.DTOs;
using UserManagementService.AsyncDataServices;

namespace UserManagementService.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMessageBusClient _publisher;
        public UserService(IUserRepository userRepository, IMessageBusClient publisher)
        {
            _userRepository = userRepository;
            _publisher = publisher;
        }
        public async Task<PaginatedUsers> GetAllUsersAsync(int page, int pageSize)
        {
            return await _userRepository.GetUsers(page, pageSize);
        }

        public async Task<UserProfileDto> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task CreateUserAsync(User user)
        {
            await _userRepository.CreateUser(user);
        }

        public async Task<bool> UpdateUserAsync(string id, UserProfileUpdateDto updatedUser)
        {
            var response =  await _userRepository.UpdateUser(id, updatedUser);
            if(response)
            {
                var userUpdatedEvent = new UserUpdatedEvent
                {
                    UserId = id,
                    Name = updatedUser.Name,
                    Bio = updatedUser.Bio,
                    ImageUrl = updatedUser.ImageUrl
                };
                _publisher.PublishUserUpdatedEvent(userUpdatedEvent);
            }
            return response;
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
        public async Task<PaginatedUsers> GetFollowersAsync(string userId, int page, int pageSize)
        {
            return await _userRepository.GetFollowers(userId, page, pageSize);
        }
        public async Task<PaginatedUsers> GetFollowingAsync(string userId, int page, int pageSize)
        {
            return await _userRepository.GetFollowing(userId, page, pageSize);
        }

        public Task<IEnumerable<UserProfileDto>> SearchUsersAsync(string query)
        {
            return _userRepository.SearchUsers(query);
        }
    }
}
