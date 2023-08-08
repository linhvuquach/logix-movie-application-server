using System.ComponentModel.DataAnnotations;

namespace Logix_Movie_Application.Models
{
    public class UserActivity : Base 
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = " This field accepts only positive numbers.")]
        public int MovieId { get; set; }
        public bool IsLiked { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = " This field accepts only positive numbers.")]
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}
