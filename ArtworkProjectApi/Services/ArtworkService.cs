using ArtworkProjectApi.DTOs;
using ArtworkProjectApi.Models;
using ArtworkProjectApi.Repositories.Interfaces;
using ArtworkProjectApi.Services.Interfaces;
using AutoMapper;

namespace ArtworkProjectApi.Services
{
    public class ArtworkService : IArtworkService
    {
        private readonly IGenericRepository<Artwork> _repo;
        private readonly IMapper _mapper;

        public ArtworkService(IGenericRepository<Artwork> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ArtworkDto>> GetAllAsync()
            => _mapper.Map<IEnumerable<ArtworkDto>>(await _repo.GetAllAsync());

        public async Task<ArtworkDto?> GetByIdAsync(int id)
        {
            var artwork = await _repo.GetByIdAsync(id);
            return artwork == null ? null : _mapper.Map<ArtworkDto>(artwork);
        }

        public async Task<ArtworkDto> CreateAsync(ArtworkDto dto)
        {
            var model = _mapper.Map<Artwork>(dto);
            await _repo.AddAsync(model);
            return _mapper.Map<ArtworkDto>(model);
        }

        public async Task<bool> UpdateAsync(int id, ArtworkDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity = await _repo.GetByIdAsync(id);
                await _repo.DeleteAsync(entity);
                
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
