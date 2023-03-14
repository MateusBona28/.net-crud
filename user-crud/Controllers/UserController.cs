using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Models;

namespace User.Controllers {

    [Route("api/[Controller]")]
    [ApiController]

    public class UserController : ControllerBase {

        [HttpGet]
        public ActionResult<List<UserModel>> GetUsers() {
            return Ok();
        }
    }
}
