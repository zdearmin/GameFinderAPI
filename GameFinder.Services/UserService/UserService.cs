using GameFinder.Data;
using GameFinder.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;

namespace GameFinder.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public UserService (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // public async Task<User> UpdateUserAsync(int userId, JsonPatchDocument userDocument)
        // {
        //     var userQuery = await GetUserByIdAsync(userId);
        //     if (userQuery == null)
        //     {
        //         return userQuery;
        //     }
        //     userDocument.ApplyTo(userQuery);
        //     await _dbContext.SaveChangesAsync();

        //     return userQuery;
        // }

        public async Task<bool> RegisterUserAsync(User model)
        {
            if (await GetUserByEmailAsync(model.Email) != null || await GetUserByUsernameAsync(model.Username) != null)
            {
                return false;
            }

            var entity = new User
            {
                Email = model.Email,
                Username = model.Username,
            };

            var passwordHasher = new PasswordHasher<User>();

            entity.Password = passwordHasher.HashPassword(entity, model.Password);

            _dbContext.Users.Add(entity);
            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<UserDetail> GetUserByIdAsync(int userId)
        {
            var entity = await _dbContext.Users.FindAsync(userId);
            if (entity is null)
            {
                return null;
            }
            
            var userDetail = new UserDetail
            {
                Id = entity.Id,
                Email = entity.Email,
                Username = entity.Username,
            };

            return userDetail;
        }

        private  async Task<UserDetail> GetUserByUsernameAsync(string username)
        {
            var entity = await _dbContext.Users.FindAsync(username);
            if (entity is null)
            {
                return null;
            }
            
            var userDetail = new UserDetail
            {
                Id = entity.Id,
                Email = entity.Email,
                Username = entity.Username,
            };

            return userDetail;
        }

        private async Task<UserDetail> GetUserByEmailAsync(string email)
        {
            var entity = await _dbContext.Users.FindAsync(email);
            if (entity is null)
            {
                return null;
            }
            
            var userDetail = new UserDetail
            {
                Id = entity.Id,
                Email = entity.Email,
                Username = entity.Username,
            };

            return userDetail;
        }

        public async Task<bool> UpdateUserAsync(User request)
        {
            var userEntity = await _dbContext.Users.FindAsync(request.Id);

            userEntity.Email = request.Email;
            userEntity.Username = request.Username;
            userEntity.Password = request.Password;
            userEntity.FirstName = request.FirstName;
            userEntity.LastName = request.LastName;

            var numberOfChanges = await _dbContext.SaveChangesAsync();

            return numberOfChanges == 1;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var userEntity = await _dbContext.Users.FindAsync(userId);

            _dbContext.Users.Remove(userEntity);

            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}