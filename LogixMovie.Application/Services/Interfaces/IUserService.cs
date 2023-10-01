using LogixMovie.Application.Dtos;

namespace LogixMovie.Application.Services.Interfaces
{
    public interface IUserService
    {
        public Task<AuthenticateDto> AuthenticateAsync(UserDto user);

        public Task<bool> RegisterAsync(UserDto user);

        public Task UserLikeOrDislikeMovieAsync(LikeOrDislikeMovieDto request);

        public Task<UserLikeOrDislikeMovieDto> GetListUserLikeOrDislikeMovieAsync(int userId);
    }
}
