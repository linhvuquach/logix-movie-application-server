using Logix_Movie_Application.Extensions;
using Logix_Movie_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Logix_Movie_Application.Data
{
    public class MovieDBContext : DbContext
    {
        protected MovieDBContext()
        {
        }

        public MovieDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedData();
        }
    }
}
