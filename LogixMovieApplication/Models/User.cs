using System.ComponentModel.DataAnnotations;

namespace Logix_Movie_Application.Models
{
    public class User : Base
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
