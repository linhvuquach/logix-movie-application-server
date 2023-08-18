using Logix_Movie_Application.Dtos;
using Logix_Movie_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Logix_Movie_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUser _userRepository;

        public LoginController(IUser userRepository, ILogger<LoginController> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserRequest user)
        {
            try
            {
                IActionResult response = Unauthorized();
                var result = await _userRepository.Authenticate(user);
                if (!(result.UserId == 0 && string.IsNullOrEmpty(result.Token)))
                {
                    return Ok(result);
                }

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while login.");
                throw;
            }
        }
    }
}