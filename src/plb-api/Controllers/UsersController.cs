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

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromHeader] string authorization)
        {
            var token = authorization?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
                return Unauthorized("Missing token");

            var firebaseToken = await _firebaseAuthService.VerifyIdToken(token);

            if (firebaseToken == null)
                return Unauthorized("Invalid token");

            var firebaseUid = firebaseToken.Uid;
            var email = firebaseToken.Claims["email"]?.ToString();

            return Ok(new
            {
                uid = firebaseUid, email
            });
        }
    }
}
