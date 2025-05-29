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
    }
}
