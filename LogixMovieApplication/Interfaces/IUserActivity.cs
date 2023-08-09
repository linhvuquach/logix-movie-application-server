using Logix_Movie_Application.Dtos;

namespace Logix_Movie_Application.Interfaces
{
    public interface IUserActivity
    {
        public Task LikeOrDislikeMovieAsync(LikeDislikeRequest request);
        public Task<UserLikeOrDislike> UserLikeOrDislikeAsync(int userId);
    }
}
