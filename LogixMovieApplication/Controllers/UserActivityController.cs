using Logix_Movie_Application.Dtos;
using Logix_Movie_Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Logix_Movie_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserActivityController : ControllerBase
    {
        private readonly ILogger<UserActivityController> _logger;
        private readonly IUser _userRepository;
        private readonly IMovie _movieRepository;
        private readonly IUserActivity _userActivityRepository;


        public UserActivityController(IUser userRepository,
            IMovie movieRepository,
            IUserActivity userActivityRepository,
            ILogger<UserActivityController> logger)
        {
            _userRepository = userRepository;
            _movieRepository= movieRepository;
            _userActivityRepository = userActivityRepository;
            _logger = logger;
        }

        [HttpPost("like-dislike")]
        public async Task<IActionResult> LikeOrDislikeMovie([FromBody] LikeDislikeRequest request)
        {
            try
            {
                var user = await _userRepository.GetByIdAsync(request.UserId);
                var movie = await _movieRepository.GetByIdAsync(request.MovieId);

                if (user != null && movie != null)
                {
                    await _userActivityRepository.LikeOrDislikeMovie(request);
                }

                return Ok(request.MovieId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while like or dislike movie.");
                throw;
            }
        }
    }
}