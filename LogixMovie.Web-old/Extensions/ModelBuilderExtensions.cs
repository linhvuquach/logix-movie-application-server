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
                    ImageUrl = "8Vt6mWEReuy4Of61Lnj5Xj704m8.jpg"
                },
                new Movie
                {
                    Id = 2,
                    Title = "Guardians of the Galaxy Vol. 3",
                    ImageUrl = "bRdR9EMEjDr5jxMRyt7fvGF0Hy2.jpg"
                },
                new Movie
                {
                    Id = 3,
                    Title = "Oppenheimer",
                    ImageUrl = "8Gxv8gSFCU0XGDykEGv7zR1n2ua.jpg"
                },
                new Movie
                {
                    Id = 4,
                    Title = "Only Murders in the Building",
                    ImageUrl = "yhx6PnU3L2a6FnEFGOlBKTZ8TSD.jpg"
                },
                new Movie
                {
                    Id = 5,
                    Title = "Squid Game",
                    ImageUrl = "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg"
                },
                new Movie
                {
                    Id = 6,
                    Title = "Money Heist",
                    ImageUrl = "reEMJA1uzscCbkpeRJeTT2bjqUp.jpg"
                },
                new Movie
                {
                    Id = 7,
                    Title = "3 Idiots",
                    ImageUrl = "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg"
                },
                new Movie
                {
                    Id = 8,
                    Title = "Game of Thrones",
                    ImageUrl = "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg"
                },
                new Movie
                {
                    Id = 9,
                    Title = "Avatar",
                    ImageUrl = "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg"
                },
                new Movie
                {
                    Id = 10,
                    Title = "Vikings",
                    ImageUrl = "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg"
                },
                new Movie
                {
                    Id = 11,
                    Title = "Game of Thrones",
                    ImageUrl = "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg"
                },
                new Movie
                {
                    Id = 12,
                    Title = "Breaking Bad",
                    ImageUrl = "uu4TgyyW259aOZHN0Ew4TEfjnUG.jpg"
                }
            );
        }
    }
}
