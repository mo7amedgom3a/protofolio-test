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
    }
}