namespace Logix_Movie_Application.Dtos
{
    public class UserLikeOrDislike
    {
        public int UserId { get; set; }
        public List<int> Likes { get; set; }
        public List<int> Dislikes { get; set; }
    }
}
