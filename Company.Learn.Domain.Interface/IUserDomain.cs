using Company.Learn.Domain.Entity;

namespace Company.Learn.Domain.Interface
{
    public interface IUserDomain
    {
        User Authenticate(string userName, string password);
    }
}
