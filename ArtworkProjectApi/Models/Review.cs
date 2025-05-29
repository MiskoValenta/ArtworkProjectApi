namespace ArtworkProjectApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; } // 1–5
        public int ArtworkId { get; set; }
        public Artwork Artwork { get; set; } = null!;
    }
}
