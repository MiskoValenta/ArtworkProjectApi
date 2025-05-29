namespace ArtworkProjectApi.DTOs
{
    public class ArtworkDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int GenreId { get; set; }
    }
}
