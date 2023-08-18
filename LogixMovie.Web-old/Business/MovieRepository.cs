using Logix_Movie_Application.Data;
using Logix_Movie_Application.Dtos;
using Logix_Movie_Application.Interfaces;
using Logix_Movie_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Logix_Movie_Application.Business
{
    public class MovieRepository : BaseRepository<Movie>, IMovie
    {
        private readonly MovieDBContext _movieDBContext;

        public MovieRepository(MovieDBContext movieDBContext) : base(movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public async Task<IEnumerable<MovieRequest>> GetAllMoviesAsync()
        {
            var result = await _movieDBContext.Movies
                .Include(m => m.UserActivities)
                .AsNoTracking()
                .Select(m => new MovieRequest
                {
                    MovieId = m.Id,
                    Title = m.Title,
                    ImageUrl = m.ImageUrl,
                    TotalLikes = m.TotalLikes,
                    TotalDislikes = m.TotalDislikes,
                })
                .ToListAsync();
            return result;
        }
    }
}
