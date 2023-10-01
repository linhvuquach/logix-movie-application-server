using LogixMovie.Application.Dtos;
using LogixMovie.Application.Services.Interfaces;
using LogixMovie.Common.Constants;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("LikeOrDislike")]
        [Authorize(Policy = UserRoles.User)]
        public async Task<IActionResult> LikeOrDislikeMovie([FromBody] LikeOrDislikeMovieDto request)
        {
            try
            {
                await _userService.UserLikeOrDislikeMovieAsync(request);
                return Ok(request.MovieId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error while user like or dislike movie");
                throw;
            }
        }

        [HttpGet("{userId}/LikeOrDislike")]
        [Authorize(Policy = UserRoles.User)]
        public async Task<IActionResult> GetListUserLikeOrDislikeMovie(int userId)
        {
            try
            {
                var result = await _userService.GetListUserLikeOrDislikeMovieAsync(userId);
                return Ok(result);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error while get list user like or dislike movie");
                throw;
            }
        }
    }
}