using Bootcamp.API.Models;

namespace Bootcamp.API.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        User GetByEmail(string email);
        void Add(User entity);
        void Update(User entity);
        void Delete(int id);

    }
}
