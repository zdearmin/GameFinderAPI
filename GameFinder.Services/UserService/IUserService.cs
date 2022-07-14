using GameFinder.Data;
using GameFinder.Data.Models;

namespace GameFinder.Services.UserService
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(User model);
        Task<UserDetail> GetUserByIdAsync(int userId);
        Task<UserDetail> GetUserByUsernameAsync(string username);
        Task<UserDetail> GetUserByEmailAsync(string email);
        Task<bool> UpdateUserAsync(User request);
        Task<bool> DeleteUserAsync(int userId);
    }
}