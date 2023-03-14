using User.Repositories.Interfaces;
using User.Models;

namespace User.Repositories {
    public class UserRepository : IUserRepository {
        public Task<List<UserModel>> GetAllUsers() {
            throw new NotImplementedException();
        }
        public Task<UserModel> GetUserById(string id) {
            throw new NotImplementedException();
        }
        public Task<UserModel> CreateNewUser(UserModel usuario) {
            throw new NotImplementedException();
        }
        public Task<UserModel> UpdateUser(UserModel usuario, string id) {
            throw new NotImplementedException();
        }
        public Task<UserModel> DeleteUser(string id) {
            throw new NotImplementedException();
        }
    }
}