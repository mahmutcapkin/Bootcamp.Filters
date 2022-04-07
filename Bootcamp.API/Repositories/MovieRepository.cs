using Bootcamp.API.Models;

namespace Bootcamp.API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private static List<Movie> _movies = new List<Movie>()
        {
            new(){Id=1,Name="Interstellar",Income=500000000, Rating=8.9, ReleaseDate=DateTime.Now.AddYears(-10).AddMonths(-5), Type=MovieType.ScienceFiction},
            new(){Id=2,Name="Shawshank Redemption",Income=750000000, Rating=9.3, ReleaseDate=DateTime.Now.AddYears(-27).AddMonths(-4), Type=MovieType.Drama},
            new(){Id=3,Name="The Dark Knight",Income=150000000, Rating=9.2, ReleaseDate=DateTime.Now.AddYears(-50).AddMonths(-2), Type=MovieType.Crime},
            new(){Id=4,Name="Inception",Income=100000000, Rating=8.8, ReleaseDate=DateTime.Now.AddYears(-12).AddMonths(2), Type=MovieType.Adventure},
            new(){Id=5,Name="Forrest Gump",Income=120000000, Rating=8.8, ReleaseDate=DateTime.Now.AddYears(-27).AddMonths(2), Type=MovieType.Drama}

        };
        public void Add(Movie movie)
        {
            _movies.Add(movie);
        }

        public void Delete(int id)
        {
            var deletedMovie = _movies.FirstOrDefault(x => x.Id == id);
            _movies.Remove(deletedMovie);
        }


        public List<Movie> GetAll()
        {
            return _movies;
        }

        public Movie GetById(int id)
        {
            return _movies.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Movie movie)
        {
            var movieIndex = _movies.FindIndex(x => x.Id == movie.Id);

            _movies[movieIndex] = movie;
        }
    }
}
