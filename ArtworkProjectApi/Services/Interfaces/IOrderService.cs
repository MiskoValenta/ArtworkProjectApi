using ArtworkProjectApi.DTOs;
using ArtworkProjectApi.Models;

namespace ArtworkProjectApi.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(OrderDto orderDto);
        Task<IEnumerable<Order>> GetAllOrderAsync();
    }
}
