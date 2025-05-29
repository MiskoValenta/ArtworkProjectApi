using ArtworkProjectApi.DTOs;

namespace ArtworkProjectApi.Services.Interfaces
{
    public interface IArtworkService
    {
        Task<IEnumerable<ArtworkDto>> GetAllAsync();
        Task<ArtworkDto?> GetByIdAsync(int id);
        Task<ArtworkDto> CreateAsync(ArtworkDto dto);
        Task<bool> UpdateAsync(int id, ArtworkDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
