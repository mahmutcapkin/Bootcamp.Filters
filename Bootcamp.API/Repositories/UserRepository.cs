using Bootcamp.API.Models;

namespace Bootcamp.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new List<User>()
        {
               new (){Id=1, UserName="ali123", Email="ali@gmail.com",Password="12345"},
               new (){Id=2, UserName="mehmet123", Email="mehmet@gmail.com",Password="1234"},
               new (){Id=3, UserName="veli123", Email="veli@gmail.com",Password="123"},
        };
        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(x => x.Id == id);
            _users.Remove(deletedUser);
        }

        public List<User> GetAll()
        {
           return _users;
        }

        public User GetById(int id)
        {
           return _users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByEmail(string email)
        {
            return _users.FirstOrDefault(x => x.Email == email);
        }

        public void Update(User user)
        {
            var userIndex = _users.FindIndex(x => x.Id == user.Id);

            _users[userIndex] = user;
        }
    }
}
