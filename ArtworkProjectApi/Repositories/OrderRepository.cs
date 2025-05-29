using ArtworkProjectApi.Data;
using ArtworkProjectApi.Models;
using ArtworkProjectApi.Repositories.Interfaces;

namespace ArtworkProjectApi.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(AppDbContext context) : base(context)
        {

        }
    }
}
