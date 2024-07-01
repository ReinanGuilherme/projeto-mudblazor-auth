﻿using Microsoft.IdentityModel.Tokens;
using MudblazorAuth.Domain.Entities;
using MudblazorAuth.Domain.Security.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MudblazorAuth.Infrastructure.Security.Tokens
{
    public class Token : IToken
    {
        private readonly uint _expirationTimeMinutes;
        private readonly string _signingKey;

        public Token(uint expirationTimeMinutes, string signingKey)
        {
            _expirationTimeMinutes = expirationTimeMinutes;
            _signingKey = signingKey;
        }

        public string Generate(Account account)
        {
            var claims = new List<Claim>()
        {
            new Claim(ClaimTypes.Name, account.Username),
            new Claim(ClaimTypes.Sid, account.Id.ToString()),
            new Claim(ClaimTypes.Role, account.IdProfile.ToString())
        };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.UtcNow.AddMinutes(_expirationTimeMinutes),
                SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(securityToken);
        }

        private SymmetricSecurityKey SecurityKey()
        {
            var key = Encoding.UTF8.GetBytes(_signingKey);

            return new SymmetricSecurityKey(key);
        }
    }
}