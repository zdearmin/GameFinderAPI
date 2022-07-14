using GameFinder.Data;
using GameFinder.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace GameFinder.Services.UserService
{
    public interface IUserService
    {
        // Task<User> UpdateUserAsync(int userId, JsonPatchDocument user);
        Task<bool> RegisterUserAsync(User model);
        Task<UserDetail> GetUserByIdAsync(int userId);
        Task<bool> UpdateUserAsync(User request);
        Task<bool> DeleteUserAsync(int userId);
    }
}