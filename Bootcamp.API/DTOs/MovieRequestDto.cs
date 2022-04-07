using Bootcamp.API.Models;

namespace Bootcamp.API.DTOs
{
    public class MovieRequestDto
    {
        public string Name { get; set; }
        public double Rating { get; set; }
        public decimal Income { get; set; }
        public MovieType Type { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
