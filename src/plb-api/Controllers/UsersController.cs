using Microsoft.AspNetCore.Mvc;
using plb_api.Services;
using plb_api.Dtos;

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
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserDto registerUser)
        {
            if (string.IsNullOrWhiteSpace(registerUser.Email) || string.IsNullOrWhiteSpace(registerUser.Password) || string.IsNullOrWhiteSpace(registerUser.Username))
            {
                return BadRequest("Email, Username, and Password are required.");
            }

            try
            {
                var user = await _firebaseAuthService.CreateUser(registerUser.Email, registerUser.Password, registerUser.Username);

                // TODO: save user info in db (e.g., db.AddUser(registerUser))

                return Ok(new
                {
                    uid = user.Uid,
                    email = user.Email,
                });
            }
            catch (Exception ex)
            {
                return BadRequest($"Error registering user: {ex.Message}");
            }

            // TODO: still using this code?

            //var token = authorization?.Split(" ").Last();
            //if (string.IsNullOrEmpty(token))
            //    return Unauthorized("Missing token");

            //var firebaseToken = await _firebaseAuthService.VerifyIdToken(token);

            //if (firebaseToken == null)
            //    return Unauthorized("Invalid token");

            //var firebaseUid = firebaseToken.Uid;
            //var email = firebaseToken.Claims["email"]?.ToString();

            //return Ok(new
            //{
            //    uid = firebaseUid, email
            //});
        }
    }
}
