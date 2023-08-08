using Logix_Movie_Application.Dtos;
using Logix_Movie_Application.Models;

namespace Logix_Movie_Application.Interfaces
{
    public interface IMovie : IBaseRepository<Movie>
    {
        Task<IEnumerable<MovieRequest>> GetAllMoviesAsync();
    }
}
