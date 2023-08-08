namespace Logix_Movie_Application.Dtos
{
    public class MovieRequest
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int TotalLikes { get; set; }
        public int TotalDislikes { get; set; }
    }
}
