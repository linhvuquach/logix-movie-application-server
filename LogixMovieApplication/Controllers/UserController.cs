using Logix_Movie_Application.Dtos;
using Logix_Movie_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Logix_Movie_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUser _userRepository;

        public UserController(IUser userRepository,
            ILogger<UserController> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserRequest user)
        {
            try
            {
                var result = await _userRepository.Register(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while register user.");
                throw;
            }
        }
    }
}