using Company.Learn.Application.DTO;

namespace Company.Learn.Service.WebApi.JWTSecurity.Contracts
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ITokenFactory'
    public interface ITokenFactory
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ITokenFactory'
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'ITokenFactory.BuildToken(UserDTO)'
        string BuildToken(UserDTO userDTO);
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'ITokenFactory.BuildToken(UserDTO)'
    }
}
