using LogixMovie.Application.Dtos;

namespace LogixMovie.Application.Services.Interfaces
{
    public interface IMovieService
    {
        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
    }
}
