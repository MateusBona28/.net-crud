using User.Models;

namespace User.Repositories.Interfaces {

    public interface IUserRepository {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(string id);
        Task<UserModel> CreateNewUser(UserModel usuario);
        Task<UserModel> UpdateUser(UserModel usuario, string id);
        Task<UserModel> DeleteUser(string id);
    }
}