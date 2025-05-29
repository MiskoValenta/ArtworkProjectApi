namespace ArtworkProjectApi.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
    }
}
