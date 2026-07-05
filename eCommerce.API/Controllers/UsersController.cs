using eCommerce.Core.DTOs;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        /// <summary>
        /// Retrieves user information based on the provided user ID.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            if (userId == Guid.Empty) return BadRequest("Invalid user ID.");
            
            UserResponseDTO? authenticationResponse = await _usersService.GetUserById(userId);
            if (authenticationResponse == null)
            {
                return NotFound(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }
    }
}
