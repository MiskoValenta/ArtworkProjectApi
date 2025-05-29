namespace ArtworkProjectApi.DTOs
{
    public class OrderDto
    {
        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int ArtworkId { get; set; }
    }
}
