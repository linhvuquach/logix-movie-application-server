using System.ComponentModel.DataAnnotations;

namespace Logix_Movie_Application.Models
{
    public class Movie : Base
    {
        [Required]
        [MaxLength(1000, ErrorMessage = "The value can not be more than 1000 characters long.")]
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<UserActivity> UserActivities { get; set; }
    }
}
