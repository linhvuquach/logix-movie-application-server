using LogixMovie.Application.Dtos;
using LogixMovie.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogixMovie.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUserService _userService;

        public UsersController(IUserService userService,
            ILogger<UsersController> logger)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto user)
        {
            try
            {
                var result = await _userService.RegisterAsync(user);
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