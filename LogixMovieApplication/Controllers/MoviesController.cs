using Logix_Movie_Application.Business;
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
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMovie _movieRepository;

        public MoviesController(IMovie movieRepository, ILogger<MoviesController> logger)
        {
            _movieRepository = movieRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieRequest>> Get()
        {
            try
            {
                var result = await _movieRepository.GetAllMoviesAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while get list movie.");
                throw;
            }
        }
    }
}