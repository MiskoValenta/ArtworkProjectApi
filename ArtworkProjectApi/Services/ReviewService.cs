using ArtworkProjectApi.DTOs;
using ArtworkProjectApi.Models;
using ArtworkProjectApi.Repositories.Interfaces;
using ArtworkProjectApi.Services.Interfaces;
using AutoMapper;

namespace ArtworkProjectApi.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IGenericRepository<Review> _reviewRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ReviewService> _logger;

        public ReviewService(IGenericRepository<Review> reviewRepository, IMapper mapper, ILogger<ReviewService> logger)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<ReviewDto>> GetAllReviewsAsync()
        {
            var reviews = await _reviewRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewDto>>(reviews);
        }

        public async Task<ReviewDto?> GetReviewByIdAsync(int id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            return review == null ? null : _mapper.Map<ReviewDto>(review);
        }

        public async Task<ReviewDto> CreateReviewAsync(ReviewDto reviewDto)
        {
            var review = _mapper.Map<Review>(reviewDto);
            await _reviewRepository.AddAsync(review);
            return _mapper.Map<ReviewDto>(review);
        }

        public async Task<bool> DeleteReviewAsync(int id)
        {
            var entity = await _reviewRepository.GetByIdAsync(id); // if entity = null -> return false nebo excep...
            try
            {
                await _reviewRepository.DeleteAsync(entity);
                return true;
            }
            catch (Exception)
            {
                // Zallogovat error
                return false;
            }
        }
    }
}
