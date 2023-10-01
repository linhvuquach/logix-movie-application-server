using LogixMovie.Application.Dtos;
using LogixMovie.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace LogixMovie.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUserService _userService;

        public LoginController(IUserService userService, ILogger<LoginController> logger)
        {
            _logger = logger;
            _userService = userService;

        }

        [HttpPost]
        public async Task<IActionResult> Login(UserDto user)
        {
            try
            {
                var result = await _userService.AuthenticateAsync(user);

                if (!(result.UserId == 0 && string.IsNullOrEmpty(result.Token)))
                {
                    return Ok(result);
                }

                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while login.");
                throw ex;
            }
        }
    }
}