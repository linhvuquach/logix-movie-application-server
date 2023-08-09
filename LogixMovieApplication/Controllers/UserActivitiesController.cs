using Logix_Movie_Application.Dtos;
using Logix_Movie_Application.Interfaces;
using Logix_Movie_Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Logix_Movie_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = UserRoles.User)]
    public class UserActivitiesController : ControllerBase
    {
        private readonly ILogger<UserActivitiesController> _logger;
        private readonly IUser _userRepository;
        private readonly IMovie _movieRepository;
        private readonly IUserActivity _userActivityRepository;

        public UserActivitiesController(IUser userRepository,
            IMovie movieRepository,
            IUserActivity userActivityRepository,
            ILogger<UserActivitiesController> logger)
        {
            _userRepository = userRepository;
            _movieRepository = movieRepository;
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
                    await _userActivityRepository.LikeOrDislikeMovieAsync(request);
                }

                return Ok(request.MovieId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while like or dislike movie.");
                throw;
            }
        }

        [HttpGet("{userId}/userLikeOrDislike")]
        public async Task<IActionResult> UserLikeOrDislike(int userId)
        {
            try
            {
                var result = await _userActivityRepository.UserLikeOrDislikeAsync(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while get User's like or dislike movies.");
                throw;
            }
        }
    }
}