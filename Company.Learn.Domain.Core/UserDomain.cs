using Company.Learn.Domain.Entity;
using Company.Learn.Domain.Interface;
using Company.Learn.Infrastructure.Interface;

namespace Company.Learn.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserRepository _userRepository;

        public UserDomain(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string userName, string password)
        {
            return _userRepository.Authenticate(userName, password);
        }
    }
}
