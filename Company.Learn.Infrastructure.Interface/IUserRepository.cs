using Company.Learn.Domain.Entity;

namespace Company.Learn.Infrastructure.Interface
{
    public interface IUserRepository
    {
        User Authenticate(string userName, string password);
    }
}
