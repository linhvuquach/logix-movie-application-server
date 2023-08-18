using LogixMovie.Domain.Entities;
using LogixMovie.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;

namespace LogixMovie.Infrastructure.Data
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
