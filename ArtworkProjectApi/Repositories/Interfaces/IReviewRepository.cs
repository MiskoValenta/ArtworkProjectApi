using ArtworkProjectApi.Data;
using ArtworkProjectApi.Models;

namespace ArtworkProjectApi.Repositories.Interfaces
{
    public interface IReviewRepository : IGenericRepository<Review>
    {
        Task<bool> DeleteAsync(int id);
        Task GetByArtworkIdAsync(int artworkId);
    }
}
