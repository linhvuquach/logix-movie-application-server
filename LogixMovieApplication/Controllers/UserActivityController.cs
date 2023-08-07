using Logix_Movie_Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Logix_Movie_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserActivityController : ControllerBase
    {
        private readonly ILogger<UserActivityController> _logger;

        public UserActivityController(ILogger<UserActivityController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> LikeMovie([FromBody] LikeDislikeRequest request)
        {
            // TODO:
            // implement like or dislike within method
            return Ok(true);
        }

        //[HttpPatch("like")]
        //public async Task<IActionResult> LikeMovie([FromBody] LikeDislikeRequest request)
        //{
        //    // Do something
        //}
    }
}