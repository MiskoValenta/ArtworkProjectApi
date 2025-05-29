using ArtworkProjectApi.DTOs;
using ArtworkProjectApi.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ArtworkProjectApi.Controllers
{
    [ApiController]
    [Route("store/[controller]")]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;
        private readonly ILogger<ReviewController> _logger;

        public ReviewController(IReviewService reviewService, IMapper mapper, ILogger<ReviewController> logger)
        {
            _reviewService = reviewService;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: store/review/artwork/5
        [HttpGet("artwork/{artworkId}")]
        public async Task<ActionResult<IEnumerable<ReviewDto>>> GetReviewsForArtwork(int artworkId)
        {
            var reviews = await _reviewService.GetReviewByIdAsync(artworkId);
            return Ok(reviews);
        }

        // POST: store/review
        [HttpPost]
        public async Task<ActionResult> AddReview([FromBody] ReviewDto reviewDto)
        {
            try
            {
                await _reviewService.CreateReviewAsync(reviewDto);
                return Ok(new { message = "Review added successfully." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding review.");
                return StatusCode(500, "An error occurred while adding the review.");
            }
        }
    }
}
