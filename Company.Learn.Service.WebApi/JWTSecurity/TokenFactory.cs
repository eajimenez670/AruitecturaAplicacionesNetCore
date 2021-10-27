using Company.Learn.Application.DTO;
using Company.Learn.Service.WebApi.Helpers;
using Company.Learn.Service.WebApi.JWTSecurity.Contracts;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Company.Learn.Service.WebApi.JWTSecurity
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TokenFactory'
    public class TokenFactory : ITokenFactory
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TokenFactory'
    {
        private readonly AppSettings _appSettings;

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TokenFactory.TokenFactory(IOptions<AppSettings>)'
        public TokenFactory(IOptions<AppSettings> appSettings)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TokenFactory.TokenFactory(IOptions<AppSettings>)'
        {
            _appSettings = appSettings.Value;
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member 'TokenFactory.BuildToken(UserDTO)'
        public string BuildToken(UserDTO userDTO)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member 'TokenFactory.BuildToken(UserDTO)'
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDTO.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
