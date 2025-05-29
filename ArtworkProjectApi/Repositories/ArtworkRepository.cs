using ArtworkProjectApi.Data;
using ArtworkProjectApi.Models;
using ArtworkProjectApi.Repositories.Interfaces;

namespace ArtworkProjectApi.Repositories
{
    public class ArtworkRepository : GenericRepository<Artwork>, IArtworkRepository
    {
        public ArtworkRepository(AppDbContext context) : base(context) { }
    }
}
