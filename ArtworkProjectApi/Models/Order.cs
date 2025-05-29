namespace ArtworkProjectApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
        public int ArtworkId { get; set; }
        public Artwork Artwork { get; set; } = null!;
    }
}
