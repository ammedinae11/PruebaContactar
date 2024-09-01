using Business.Interfaces;
using Common.Helpers;
using DTO.Request.Token;
using DTO.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.BLL
{
    public class TokenBLL : IToken
    {
        private readonly IConfiguration _configuration;

        public TokenBLL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<GenericResponse<TokenResponse>> Token(TokenRequest loginRequest)
        {
            try
            {
                //Validations necessary for login, below is an example simulating a query to the correct database
                bool Validacion = true;

                TokenSearchResponse searchUser = new()
                {
                    CampanaId = 1,
                    Username = "Example",
                    Id = 1,
                };

                if (Validacion)
                {
                    string Token = BuildToken(Encrypt.EncriptarSHA512(_configuration.GetSection("NameSite").Value + "OutS0urc1ng2023SdSWcB"), searchUser);
                    TokenResponse loginresponse = new()
                    {
                        Token = Token
                    };
                    return GenericResponse<TokenResponse>.ResponseOK(loginresponse);
                }

                return GenericResponse<TokenResponse>.ResponseValidation("Credenciales incorrectas");

            }
            catch (Exception ex)
            {
                return GenericResponse<TokenResponse>.ResponseError(ex.Message);
            }
        }

        private string BuildToken(string secret, TokenSearchResponse UserData)
        {
            var claims = new[]
            {
             new Claim(ClaimTypes.NameIdentifier,UserData.Id.ToString()),
             new Claim(ClaimTypes.Name, UserData.Username),
         };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = credenciales
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
    }
}
