using Company.Learn.Application.DTO;
using Company.Learn.Application.Interface;
using Company.Learn.Service.WebApi.JWTSecurity.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Learn.Service.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UserController'
    public class UserController : Controller
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UserController'
    {
        private readonly IUserApplication _userApplication;
        private readonly ITokenFactory _tokenFactory;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UserController.UserController(IUserApplication, ITokenFactory)'
        public UserController(IUserApplication userApplication, ITokenFactory tokenFactory)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UserController.UserController(IUserApplication, ITokenFactory)'
        {
            _userApplication = userApplication;
            _tokenFactory = tokenFactory;
        }

        [AllowAnonymous]
        [HttpPost("login")]
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'UserController.Authenticate(UserDTO)'
        public IActionResult Authenticate([FromBody] UserDTO userDTO)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'UserController.Authenticate(UserDTO)'
        {
            var response = _userApplication.Authenticate(userDTO.UserName, userDTO.Password);
            if (response.IsSuccess)
            {
                response.Data.Token = _tokenFactory.BuildToken(response.Data);
                return Ok(response);
            }

            return BadRequest(response);
        }
    }
}
