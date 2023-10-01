using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogixMovie.Domain.Models
{
    public class UserLikeOrDislikeMovie
    {
        public int UserId { get; set; }
        public IEnumerable<int> Likes { get; set; }
        public IEnumerable<int> Dislikes { get; set; }
    }
}
