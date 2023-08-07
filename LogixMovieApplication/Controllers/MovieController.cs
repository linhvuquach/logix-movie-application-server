using Logix_Movie_Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Logix_Movie_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //public async Task<List<Movie>> Get()
        public async Task<IActionResult> Get()
        {
            // TODO:
            // GET list movie
            var result = true;
            return Ok(result);
        }
    }
}