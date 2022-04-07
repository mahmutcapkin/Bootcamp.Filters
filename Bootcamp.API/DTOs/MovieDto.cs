using Bootcamp.API.Models;

namespace Bootcamp.API.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Rating { get; set; }
        public decimal Income { get; set; }
        public string Type { get; set; }
        public DateTime ReleaseDate { get; set; }

        public MovieDto()
        {
                
        }
        public MovieDto(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            Rating = movie.Rating;
            Income = movie.Income;
            Type = movie.Type.ToString();
            ReleaseDate = movie.ReleaseDate;
        }

    }
}
