using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogixMovie.Application.Dtos
{
    public class UserLikeOrDislikeMovieDto
    {
        public int UserId { get; set; }
        public IEnumerable<int> Likes { get; set; }
        public IEnumerable<int> Dislikes { get; set; }
    }
}
