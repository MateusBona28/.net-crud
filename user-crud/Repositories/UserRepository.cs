using Microsoft.EntityFrameworkCore;
using User.Repositories.Interfaces;
using User.Models;
using User.Data;

namespace User.Repositories {
    public class UserRepository : IUserRepository {

        private readonly UserDbContext _dbContext;

        public UserRepository(UserDbContext userDbContext) {
            _dbContext = userDbContext;
        }
        public async Task<List<UserModel>> GetAllUsers() {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<UserModel> GetUserById(string id) {
            return await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
        }
        public async Task<UserModel> CreateNewUser(UserModel user) {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }
        public async Task<UserModel> UpdateUser(UserModel user, string id) {
            UserModel userById = await GetUserById(id);

            if(userById == null)
            {
                throw new Exception("user not found");
            }

            userById.Email = user.Email;
            userById.Password = user.Password;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;
        }
        public async Task<bool> DeleteUser(string id) {

            UserModel userById = await GetUserById(id);

            if(userById == null)
            {
                throw new Exception("user not found");
            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}