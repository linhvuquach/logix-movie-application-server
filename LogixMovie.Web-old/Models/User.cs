using System.ComponentModel.DataAnnotations;

namespace Logix_Movie_Application.Models
{
    public class User : Base
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
