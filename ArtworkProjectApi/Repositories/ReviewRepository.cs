using ArtworkProjectApi.Data;
using ArtworkProjectApi.Models;
using ArtworkProjectApi.Repositories.Interfaces;

namespace ArtworkProjectApi.Repositories
{
    public class ReviewRepository :  GenericRepository<Review>, IReviewRepository
    {
        public ReviewRepository(AppDbContext context) : base(context) { }
    }
}
