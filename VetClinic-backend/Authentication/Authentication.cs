﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using VetClinic_backend.Models;

namespace VetClinic_backend.Authentication
{
    public class Authentication : IAuthentication
    {
        private readonly string _key;
        public Authentication(string key)
        {
            _key = key;
        }
        public string GenerateAuthenticationToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim("id", user.Id.ToString()),
                        new Claim("email", user.Email.ToString()),
                        new Claim("name", user.Name.ToString()),
                        new Claim("surname", user.Surname.ToString()),
                    }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var roles = Enum.GetValues(user.Role.GetType()).Cast<Enum>().Where(user.Role.HasFlag);
            foreach (var role in roles)
            {
                tokenDescriptor.Subject.AddClaim(new Claim("role", role.ToString()));
            }
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
