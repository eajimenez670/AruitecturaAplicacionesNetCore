using Company.Learn.Application.DTO;
using Company.Learn.Cross.Common;

namespace Company.Learn.Application.Interface
{
    public interface IUserApplication
    {
        Response<UserDTO> Authenticate(string userName, string password);
    }
}
