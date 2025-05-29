using ArtworkProjectApi.DTOs;

namespace ArtworkProjectApi.Services.Interfaces
{
    public interface IArtworkService
    {
        Task<ArtworkDto> CreateAsync(ArtworkDto dto);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ArtworkDto>> GetAllAsync();
        Task<ArtworkDto?> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, ArtworkDto dto);
    }
}