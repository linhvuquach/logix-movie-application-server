using Logix_Movie_Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Logix_Movie_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserRequest user)
        {
            // Do something
            return Ok(user);
        }
    }
}