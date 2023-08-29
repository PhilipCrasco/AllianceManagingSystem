using Domain.Models.Users;
using EntityFramework.Jwt;
using EntityFramework.StoreContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace EntityFramework.Services
{
    public class UserService : IUserService
    {

        private readonly Datacontext _context;
        private readonly IConfiguration _configuration;
  

        public UserService(Datacontext context , IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == request.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return null;

            var token = await GenerateJwtTokenAsync(user.Username);
            return new AuthenticateResponse(user, token);
        }


        private async Task<string> GenerateJwtTokenAsync(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("your-base64-secret-key-here");

            //var currentTime = DateTime.UtcNow;
            //var expirationTime = currentTime.AddHours(Convert.ToDouble(_configuration["Jwt:ExpirationHours"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                //Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["Jwt:ExpirationHours"])),
                //SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["Jwt:ExpirationHours"])),
                SigningCredentials =  new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }




    }
}
