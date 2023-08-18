using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogixMovie.Domain.Entities
{
    public class Movie : Base
    {
        [Required]
        [MaxLength(1000, ErrorMessage = "The value can not be more than 1000 characters long.")]
        public string Title { get; set; }
        public string ImageUrl { get; set; }

        public virtual ICollection<UserActivity> UserActivities { get; set; }

        public int TotalLikes => UserActivities.Count(ua => ua.IsLiked);
        public int TotalDislikes => UserActivities.Count(ua => !ua.IsLiked);
    }
}
