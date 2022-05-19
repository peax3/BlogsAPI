using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using BlogsAPI.Models;
using Microsoft.IdentityModel.Tokens;

namespace BlogsAPI.Services
{
    public class TokenService
    {
        private string tokenSignatureKey = "bcewgcwhyocwyyqpuquddnehhdwehe";
        
        public async Task<string> GenerateToken(User user)
        {
            
            // hold information about the token
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.Now.AddMinutes(30)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}