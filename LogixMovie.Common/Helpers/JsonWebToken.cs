using LogixMovie.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using LogixMovie.Common.Constants;

namespace LogixMovie.Common.Helpers
{
    public static class JsonWebToken
    {
        public static string GenerateJSONWebToken(User user)
        {
            // TODO:
            // Get jwt's key configuration from appSetting

            string jwtSecretKey = "E6ls8Q47g8UBzySY";
            string jwtIssuer = "logixMovieIssuer";
            string jwtAudience = "logixMoieAudience";
            int jwtExpired = 24;

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey));
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
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: userClaims,
                expires: DateTime.Now.AddHours(Convert.ToDouble(jwtExpired)),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}