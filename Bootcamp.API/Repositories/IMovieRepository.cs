using Bootcamp.API.Models;
using System.Linq.Expressions;

namespace Bootcamp.API.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie entity);
        void Update(Movie entity);
        void Delete(int id);
    }
}
