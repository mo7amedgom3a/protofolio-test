using MongoDB.Driver;
using UserManagementService.Models;
using UserManagementService.Interfaces;
using UserManagementService.DTOs;
using AutoMapper;
namespace UserManagementService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<User> _users;
        private readonly IMapper _mapper;
        public UserRepository(IMongoDatabase database, IMapper mapper)
        {
            _users = database.GetCollection<User>("Users");
            _mapper = mapper;
        }
        public async Task<IList<User>> GetUsers()
        {
            return await _users.Find(user => true).ToListAsync();
        }
        public async Task<User> GetUser(string id)
        {
            return await _users.Find(user => user.Id == id).FirstOrDefaultAsync();
        }
        public async Task<User> CreateUser(User user)
        {
            try
            {
                await _users.InsertOneAsync(user);
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateUser(string id, UserProfileUpdateDto userDto)
        {
            var user = await _users.Find(user => user.Id == id).FirstOrDefaultAsync();
            if (user == null)
            {
                return false;
            }
            var updatedUser = _mapper.Map(userDto, user);
            var result = await _users.ReplaceOneAsync(user => user.Id == id, updatedUser);
            return result.IsAcknowledged && result.ModifiedCount > 0;
        }
        public async Task<bool> DeleteUser(string id)
        {
            var result = await _users.DeleteOneAsync(user => user.Id == id);
            return result.IsAcknowledged && result.DeletedCount > 0;
        }
        public async Task<bool> FollowUser(string userId, string targetId)
        {
            var user = await _users.Find(user => user.Id == userId).FirstOrDefaultAsync();
            var targetUser = await _users.Find(user => user.Id == targetId).FirstOrDefaultAsync();
            if (user == null || targetUser == null)
            {
                return false;
            }
            // Check if user is already following target
            if (user.Following.Contains(targetId))
            {
                return true;
            }
            user.Following.Add(targetId); // Add target to user's following list
            targetUser.Followers.Add(userId); // Add user to target's followers list
            var result = await _users.ReplaceOneAsync(u => u.Id == userId, user);
            var targetResult = await _users.ReplaceOneAsync(u => u.Id == targetId, targetUser);
            return result.IsAcknowledged && result.ModifiedCount > 0 && targetResult.IsAcknowledged && targetResult.ModifiedCount > 0;
        }
        public async Task<bool> UnfollowUser(string userId, string targetId)
        {
            var user = await _users.Find(user => user.Id == userId).FirstOrDefaultAsync();
            var targetUser = await _users.Find(user => user.Id == targetId).FirstOrDefaultAsync();
            if (user == null || targetUser == null)
            {
                return false;
            }
            if (!user.Following.Contains(targetId))
            {
                return true;
            }
            user.Following.Remove(targetId);
            targetUser.Followers.Remove(userId);
            var result = await _users.ReplaceOneAsync(u => u.Id == userId, user);
            var targetResult = await _users.ReplaceOneAsync(u => u.Id == targetId, targetUser);
            return result.IsAcknowledged && result.ModifiedCount > 0 && targetResult.IsAcknowledged && targetResult.ModifiedCount > 0;
        }
        public async Task<List<User>> GetFollowers(string userId)
        {
            var user = await _users.Find(user => user.Id == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            var followers = await _users.Find(user => user.Following.Contains(userId)).ToListAsync();
            return followers;
        }
        public async Task<List<User>> GetFollowing(string userId)
        {
            var user = await _users.Find(user => user.Id == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                return null;
            }
            var following = await _users.Find(user => user.Followers.Contains(userId)).ToListAsync();
            return following;
        }
    }
}