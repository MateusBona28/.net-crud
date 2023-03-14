using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Models;
using User.Repositories.Interfaces;

namespace User.Controllers {

    [Route("api/[Controller]")]
    [ApiController]

    public class UserController : ControllerBase {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> GetUsers() {
            List<UserModel> users = await _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUser(int id) {
            UserModel user = await _userRepository.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUser([FromBody]UserModel user) {
            UserModel createdUser = await _userRepository.CreateNewUser(user);
            return Ok(createdUser);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<UserModel>> UpdateUser([FromBody]UserModel userInfo, int id) {
            UserModel updatedUser = await _userRepository.UpdateUser(userInfo, id);
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id) {
            await _userRepository.DeleteUser(id);
            return true;
        }
    }
}
