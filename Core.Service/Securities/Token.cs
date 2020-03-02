using Core.Domain.Models;
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

namespace Core.Service.Securities
{
    public class Token
    {
        protected readonly IConfiguration _configuration;

        public Token(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="User"></param>
        /// <returns>Token</returns>
        private async Task<string> GenerateToken(User user)
        {
            string token = string.Empty;
            string Issuer = string.Empty;
            string Audience = string.Empty;
            string Key = string.Empty;
            string Jti = string.Empty;
            string Role = string.Empty;
            string Username = string.Empty;

            DateTime CurrentDay = DateTime.MinValue;
            DateTime IssuedAt = DateTime.MinValue;
            DateTime NotBefore = DateTime.MinValue;
            DateTime Expires = DateTime.MinValue;

            try
            {
                // Set Data
                CurrentDay = DateTime.UtcNow;
                Jti = Guid.NewGuid().ToString();
                Issuer = _configuration["Tokens:Issuer"];
                Audience = _configuration["Tokens:Issuer"];
                Key = _configuration["JWT:Key"];
                IssuedAt = CurrentDay;
                NotBefore = CurrentDay;
                Expires = CurrentDay.AddMinutes(int.Parse(_configuration["Jwt:Expires"]));
                Role = user.UserRoles.FirstOrDefault().Role.Denomination;
                Username = user.Username;

                var claims = await this.GetClaims(Username, Role, Jti, Issuer, Audience, IssuedAt, Expires);
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
                token = jwtTokenHandler.WriteToken(jwtToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return await Task.Run(() => token);
        }

        /// <summary>
        /// Get claims 
        /// </summary>
        /// <param name="Username"></param>
        /// <param name="Role"></param>
        /// <param name="Issuer"></param>
        /// <param name="Audience"></param>
        /// <param name="IssuedAt"></param>
        /// <param name="Expires"></param>
        /// <returns>claims</returns>
        private async Task<List<Claim>> GetClaims(string Username, string Role, string Jti, string Issuer, string Audience, DateTime IssuedAt, DateTime Expires)
        {
            if (string.IsNullOrEmpty(Jti)){
                Jti = Guid.NewGuid().ToString();
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Username),
                new Claim(ClaimTypes.Role, Role),
                new Claim(JwtRegisteredClaimNames.Jti, Jti), 
                new Claim(JwtRegisteredClaimNames.Iss, Issuer),
                new Claim(JwtRegisteredClaimNames.Aud, Audience),
                new Claim(JwtRegisteredClaimNames.Iat, IssuedAt.ToString(), ClaimValueTypes.Integer),
                new Claim(JwtRegisteredClaimNames.Exp, Expires.ToString(), ClaimValueTypes.Integer)
            };

            return await Task.Run(() => claims);
        }

        private async Task<string> GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
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
