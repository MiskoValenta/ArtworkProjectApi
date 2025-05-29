using ArtworkProjectApi.DTOs;

namespace ArtworkProjectApi.Services.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewDto>> GetReviewsByArtworkIdAsync(int artworkId);
        Task AddReviewAsync(ReviewDto dto);
    }
}
