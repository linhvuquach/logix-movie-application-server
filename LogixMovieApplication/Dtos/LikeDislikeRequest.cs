namespace Logix_Movie_Application.Dtos
{
    public class LikeDislikeRequest
    {
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public bool IsLiked { get; set; }
    }
}
