using ArtworkProjectApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArtworkProjectApi.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
                    new Genre { Id = 1, Name = "Abstrakce" },
                    new Genre { Id = 2, Name = "Design Decor Art" },
                    new Genre { Id = 3, Name = "Krajiny" },
                    new Genre { Id = 4, Name = "Motiv" },
                    new Genre { Id = 5, Name = "Zvířata" }
            );
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    Username = "admin",
                    Password = "password123"
                });
            modelBuilder.Entity<Artwork>().HasData(
                new Artwork
                {
                    Id = 1,
                    Title = "Slunečnice",
                    Description = "Krásný obraz slunečnic v poli",
                    Price = 1500.00m,
                    ImageUrl = "https://example.com/images/slunecnice.jpg",
                    GenreId = 1
                },
                new Artwork
                {
                    Id = 2,
                    Title = "Noční krajina",
                    Description = "Temná krajina pod hvězdnou oblohou.",
                    Price = 2300.00m,
                    ImageUrl = "https://example.com/images/nocni_krajina.jpg",
                    GenreId = 2
                });
        }
    }
}
