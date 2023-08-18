namespace Logix_Movie_Application.Dtos
{
    public class LikeDislikeRequest
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public bool IsLiked { get; set; }
    }
}
