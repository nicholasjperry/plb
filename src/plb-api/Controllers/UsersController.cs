using Microsoft.AspNetCore.Mvc;
using plb_api.Services;

namespace plb_api.Controllers

{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly FirebaseAuthService _firebaseAuthService;
        public UsersController(FirebaseAuthService firebaseAuthService)
        {
            _firebaseAuthService = firebaseAuthService;
        }

        //[HttpPost("register")]
        //public async Task<IActionResult> RegisterUser([FromHeader] string authorization)
        //{

        //}
    }
}
