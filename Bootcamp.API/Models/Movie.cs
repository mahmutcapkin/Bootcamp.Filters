namespace Bootcamp.API.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public decimal Income { get; set; }
        public MovieType Type { get; set; }
        public DateTime ReleaseDate { get; set; }

    }
}
