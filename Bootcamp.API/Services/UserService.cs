using AutoMapper;
using Bootcamp.API.Repositories;

namespace Bootcamp.API.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public bool Verify(string email,string password)
        {
            var result = _userRepository.GetByEmail(email);
            if (result == null || result.Password!=password)
            {
                return false;
            }
            return true;
        }


    }
}
