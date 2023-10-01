using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogixMovie.Application.Dtos
{
    public class LikeOrDislikeMovieDto
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public bool IsLiked { get; set; }
    }
}
