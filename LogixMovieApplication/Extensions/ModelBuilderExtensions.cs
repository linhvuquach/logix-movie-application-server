using Logix_Movie_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Logix_Movie_Application.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    Id = 1,
                    Title= "Spider-Man: Across the Spider-Verse",
                    ImageUrl = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/8Vt6mWEReuy4Of61Lnj5Xj704m8.jpg"
                },
                new Movie
                {
                    Id = 2,
                    Title = "Guardians of the Galaxy Vol. 3",
                    ImageUrl = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/bRdR9EMEjDr5jxMRyt7fvGF0Hy2.jpg"
                },
                new Movie
                {
                    Id = 3,
                    Title = "Oppenheimer",
                    ImageUrl = "https://www.themoviedb.org/t/p/w600_and_h900_bestv2/8Gxv8gSFCU0XGDykEGv7zR1n2ua.jpg"
                }
            );
        }
    }
}
