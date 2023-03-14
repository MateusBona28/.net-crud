using User.Models;

namespace User.Repositories.Interfaces {

    public interface IUserRepository {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(int id);
        Task<UserModel> CreateNewUser(UserModel usuario);
        Task<UserModel> UpdateUser(UserModel usuario, int id);
        Task<bool> DeleteUser(int id);
    }
}