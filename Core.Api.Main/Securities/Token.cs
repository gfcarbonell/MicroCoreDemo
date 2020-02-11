using Core.Domain.Models.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Main.Securities
{
    public class Token
    {
        protected readonly IConfiguration _configuration;

        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private async Task<string> GenerateToken(User user)
        {
            string Issuer = _configuration["Tokens:Issuer"];
            string Audience = _configuration["Tokens:Issuer"];
            string Key = _configuration["JWT:Key"];

            DateTime IssuedAt = DateTime.UtcNow;
            DateTime NotBefore = IssuedAt;
            DateTime Expires = IssuedAt.AddMinutes(int.Parse(_configuration["Jwt:Expires"]));

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.UserRoles.FirstOrDefault().Role.Denomination),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, IssuedAt.ToString(), ClaimValueTypes.Integer),
                new Claim(JwtRegisteredClaimNames.Exp, Expires.ToString(), ClaimValueTypes.Integer),

                //new Claim(JwtRegisteredClaimNames.Iss, Issuer),
                //new Claim(JwtRegisteredClaimNames.Aud, Audience),
            };

            ClaimsIdentity Subject = new ClaimsIdentity(claims);

            SymmetricSecurityKey SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            SigningCredentials SigningCredentials = new SigningCredentials(SymmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = Issuer,
                Audience = Audience,
                IssuedAt = IssuedAt,
                NotBefore = NotBefore,
                Expires = Expires,
                Subject = Subject,
                SigningCredentials = SigningCredentials
            };

            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            return await Task.Run(() => token);
        }

        private async Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return await Task.Run(() => Convert.ToBase64String(randomNumber));
            }
        }

        private ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, 
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the server key used to sign the JWT token is here, use more than 16 chars")),
                ValidateLifetime = true
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var claimsPrincipal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return claimsPrincipal;
        }
    }
}
