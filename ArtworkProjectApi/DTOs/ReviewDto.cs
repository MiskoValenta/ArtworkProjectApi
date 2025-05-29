namespace ArtworkProjectApi.DTOs
{
    public class ReviewDto
    {
        public string ReviewerName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public int ArtworkId { get; set; }
    }
}
