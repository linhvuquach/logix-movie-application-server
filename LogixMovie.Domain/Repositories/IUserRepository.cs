using LogixMovie.Domain.Entities;
using LogixMovie.Domain.Models;

namespace LogixMovie.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> AddUserAsync(User user);

        public Task UserLikeOrDislikeMovieAsync(LikeOrDislikeMovie request);

        public Task<UserLikeOrDislikeMovie> GetListUserLikeOrDislikeMovieAsync(int userId);
    }
}
