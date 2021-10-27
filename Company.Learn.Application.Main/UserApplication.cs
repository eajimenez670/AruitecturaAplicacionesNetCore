using AutoMapper;
using Company.Learn.Application.DTO;
using Company.Learn.Application.Interface;
using Company.Learn.Application.Validator;
using Company.Learn.Cross.Common;
using Company.Learn.Domain.Interface;
using System;

namespace Company.Learn.Application.Main
{
    public class UserApplication : IUserApplication
    {
        private readonly IUserDomain _userDomain;
        private readonly IMapper _mapper;
        private readonly UserDTOValidator _userDTORules;

        public UserApplication(IUserDomain userDomain, IMapper mapper, UserDTOValidator userDTORules)
        {
            _userDomain = userDomain;
            _mapper = mapper;
            _userDTORules = userDTORules;
        }

        public Response<UserDTO> Authenticate(string userName, string password)
        {
            var response = new Response<UserDTO>();
            var validation = _userDTORules.Validate(new UserDTO()
            {
                UserName = userName,
                Password = password
            });
            if (!validation.IsValid)
            {
                response.Message = "Errores de validación";
                response.Errors = validation.Errors;
                return response;
            }
            try
            {
                var user = _userDomain.Authenticate(userName, password);
                response.Data = _mapper.Map<UserDTO>(user);
                response.IsSuccess = true;
                response.Message = "Autenticación exitosa!!";
            }
            catch (InvalidOperationException)
            {
                response.Message = "Usuario o contraseña inválidos.";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }
    }
}
