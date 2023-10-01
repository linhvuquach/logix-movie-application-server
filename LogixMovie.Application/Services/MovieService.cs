using AutoMapper;
using LogixMovie.Application.Dtos;
using LogixMovie.Application.Services.Interfaces;
using LogixMovie.Domain.Repositories;

namespace LogixMovie.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            return _mapper.Map<IEnumerable<MovieDto>>(movies);
        }
    }
}
