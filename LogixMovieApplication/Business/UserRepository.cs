using Logix_Movie_Application.Data;
using Logix_Movie_Application.Dtos;
using Logix_Movie_Application.Helpers;
using Logix_Movie_Application.Interfaces;
using Logix_Movie_Application.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Logix_Movie_Application.Business
{
    public class UserRepository : BaseRepository<User>, IUser
    {
        private readonly MovieDBContext _movieDBContext;
        private readonly IConfiguration _config;

        public UserRepository(IConfiguration config, MovieDBContext movieDBContext) : base(movieDBContext)
        {
            _config = config;
            _movieDBContext = movieDBContext;
        }

        public async Task<bool> Register(UserRequest user)
        {
            bool isEmailAvailable = await CheckEmailAvailability(user.Email);
            if (isEmailAvailable)
            {
                string passwordHashed = PasswordHandler.HashPassword(user.Password, out var salt);
                await _movieDBContext.Users.AddAsync(new Models.User
                {
                    Email = user.Email,
                    Password = passwordHashed,
                    Salt = Convert.ToBase64String(salt)
                });
                await _movieDBContext.SaveChangesAsync();

                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<AuthenticateUser> Authenticate(UserRequest user)
        {
            AuthenticateUser authenticateUser = new();

            var userDetail = await _movieDBContext.Users
                .FirstOrDefaultAsync(u => u.Email == user.Email);

            if (userDetail == null) return authenticateUser;

            bool isPasswordValid = PasswordHandler.VerifyPassword(user.Password, userDetail.Password, userDetail.Salt);

            if (isPasswordValid)
            {
                var token = GenerateJSONWebToken(userDetail);
                authenticateUser = new AuthenticateUser
                {
                    UserId = userDetail.Id,
                    Email = userDetail.Email,
                    Token = token
                };
            }

            return authenticateUser;
        }

        public async Task<bool> CheckEmailAvailability(string email)
        {
            var result = await _movieDBContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return result == null;
        }

        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> userClaims = new()
            {
                new Claim(JwtRegisteredClaimNames.Name, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, UserRoles.User),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,UserRoles.User),
                new Claim("userId", user.Id.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: userClaims,
                expires: DateTime.Now.AddHours(Convert.ToDouble(_config["Jwt:Expired"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
