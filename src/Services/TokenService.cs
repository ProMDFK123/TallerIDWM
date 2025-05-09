using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

using api.src.Interfaces;
using api.src.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


namespace TallerIDWM.src.Services
{
    public class TokenService : ITokenServices
    {
        private readonly IConfiguration  _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            var SignInKey = _config["JWT:SiningKey"] ?? throw new ArgumentNullException("Key not found");
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SignInKey));
        }

        public string GenerateToken(User user, string role)
        {
            var claims = new List<Claim>
            {
                new (JwtRegisteredClaimNames.Email, user.Email),
                new (JwtRegisteredClaimNames.GivenName, user.FirstName),
                new (ClaimTypes.Role, role),
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}