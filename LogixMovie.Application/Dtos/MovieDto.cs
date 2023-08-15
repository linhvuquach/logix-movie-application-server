using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogixMovie.Application.Dtos
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int TotalLikes { get; set; }
        public int TotalDislikes { get; set; }
    }
}
