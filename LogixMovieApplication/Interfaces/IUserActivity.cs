using Logix_Movie_Application.Dtos;

namespace Logix_Movie_Application.Interfaces
{
    public interface IUserActivity
    {
        public Task LikeOrDislikeMovie(LikeDislikeRequest request);
    }
}
