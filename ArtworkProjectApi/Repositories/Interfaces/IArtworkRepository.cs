using ArtworkProjectApi.Models;

namespace ArtworkProjectApi.Repositories.Interfaces
{
    public interface IArtworkRepository : IGenericRepository<Artwork>
    {
        Task CreateAsync(Artwork model);
        Task<bool> DeleteAsync(int id);
    }
}
