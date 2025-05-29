using ArtworkProjectApi.DTOs;
using ArtworkProjectApi.Models;
using ArtworkProjectApi.Repositories.Interfaces;
using ArtworkProjectApi.Services.Interfaces;
using AutoMapper;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace ArtworkProjectApi.Services
{
    public class OrderService : IOrderService
    // Služba pro zpracování objednávek - vytváření a získávání
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderService> _logger;
        public OrderService(
            IOrderRepository orderRepository,
            IMapper mapper,
            ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Order> CreateOrderAsync(OrderDto orderDto)
        {
            try
            {
                var order = _mapper.Map<Order>(orderDto);
                order.OrderDate = DateTime.UtcNow;

                await _orderRepository.AddAsync(order);
                _logger.LogInformation(
                    message: $"Nová objednávka byla úspěšně vytvořena. Email zákazníka: {0}",
                    order.Email);
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při vytváření objednávky.");
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllOrderAsync()
        {
            try
            {
                var orders = await _orderRepository.GetAllAsync();
                _logger.LogInformation("Bylo načteno {Count} objednávek.", orders.Count());
                return orders;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Chyba při načítání objednávek.");
                throw;
            }
        }
    }
}
