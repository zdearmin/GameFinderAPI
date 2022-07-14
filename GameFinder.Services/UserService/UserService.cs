using GameFinder.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GameFinder.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _dbContext;
        public UserService (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

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
                DateCreated = DateTime.Now
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
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateCreated = entity.DateCreated
            };

            return userDetail;
        }

        private async Task<UserDetail> GetUserByUsernameAsync(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Username.ToLower() == username.ToLower());
        }

        private async Task<UserDetail> GetUserByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
        }

        public async Task<bool> UpdateUserAsync(User request)
        {

        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            
        }
    }
}