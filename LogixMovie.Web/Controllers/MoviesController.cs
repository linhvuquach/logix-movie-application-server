using LogixMovie.Application.Dtos;
using LogixMovie.Application.Services.Interfaces;
using LogixMovie.Common.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogixMovie.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = UserRoles.User)]
    public class MoviesController : ControllerBase
    {
        private readonly ILogger<MoviesController> _logger;
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService, ILogger<MoviesController> logger)
        {
            _movieService = movieService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            try
            {
                var result = await _movieService.GetAllMoviesAsync();
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
