using eCommerce.Core.DTOs;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        /// <summary>
        /// Authenticates a user based on the provided login credentials.
        /// </summary>
        /// <param name="loginRequest">An object containing the user's login credentials. Cannot be null.</param>
        /// <returns>An IActionResult that represents the result of the authentication attempt. Returns a success response if
        /// authentication is successful; otherwise, returns an error response.</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null) 
            {
                return BadRequest("Invalid login data.");
            }
            AuthenticationResponse? authenticationResponse = await _usersService.Login(loginRequest);
            if (authenticationResponse == null || !authenticationResponse.IsAuthenticated)
            {
                return Unauthorized(authenticationResponse);
            }
            return Ok(authenticationResponse);

        }
        /// <summary>
        /// Registers a new user in the system.
        /// </summary>
        /// <param name="registerRequest"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null)
            {
                return BadRequest("Invalid user data.");
            }
            AuthenticationResponse? authenticationResponse = await _usersService.Register(registerRequest);
            if (authenticationResponse == null || !authenticationResponse.IsAuthenticated)
            {
                return BadRequest(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }
    }
}
