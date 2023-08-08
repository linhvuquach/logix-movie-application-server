using Logix_Movie_Application.Data;
using Logix_Movie_Application.Interfaces;
using Logix_Movie_Application.Models;

namespace Logix_Movie_Application.Business
{
    public class MovieRepository : BaseRepository<Movie>, IMovie
    {
        private readonly MovieDBContext _movieDBContext;

        public MovieRepository(MovieDBContext movieDBContext) : base(movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }
    }
}
