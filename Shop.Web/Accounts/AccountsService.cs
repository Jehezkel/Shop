using System.Reflection.Metadata;
using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Collections.Generic;

namespace Shop.Web.Accounts
{
    public class AccountsService
    {
        IConfiguration _configuration;
        public AccountsService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public JwtSecurityToken CreateJwtToken(string userId)
        {
            var IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Auth:Jwt:Key"])
            );
            var tokenExpiriationMins = 480;
            return new JwtSecurityToken("https://localhost:5001",
                                        "https://localhost:5001",
                                        GetTokenClaims(userId),
                                        DateTime.Now,
                                        DateTime.Now.AddMinutes(tokenExpiriationMins),
                                        new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha256));
        }
        private IEnumerable<Claim> GetTokenClaims(string userId)
        {
            return new List<Claim>{
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString())
            };
        }

    }
}