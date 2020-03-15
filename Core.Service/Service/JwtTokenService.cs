using Core.Domain.Models;
using Core.Service.Contract.IServices;
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

namespace Core.Service.Service
{
    public class JwtTokenService : IJwtTokenService
    {
        protected readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public JwtToken Add(JwtToken element)
        {
            throw new NotImplementedException();
        }

        public Task<JwtToken> AddAsync(JwtToken element)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerateRefreshTokenAsync()
        {
            byte[] randomNumber = new byte[32];
            string refreshToken = string.Empty;

            try
            {
                RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();
                randomNumberGenerator.GetBytes(randomNumber);
                refreshToken = Convert.ToBase64String(randomNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return await Task.Run(() =>  refreshToken);
        }

        public async Task<JwtToken> GenerateTokenAsync(string name, string role, string issuer, string audience, int expires, string key)
        {
            // Set data default
            JwtToken jwtToken = new JwtToken()
            {
                Token = string.Empty,
                Issuer = string.Empty,
                Audience = string.Empty,
                Jti = string.Empty,
                IssuedAt = DateTime.MinValue,
                NotBefore = DateTime.MinValue,
                Expires = DateTime.MinValue
            };

            DateTime currentDay = DateTime.MinValue;
            string jti = string.Empty;

            try
            {
                // Set Data
                currentDay = DateTime.UtcNow;
                jti = Guid.NewGuid().ToString();

                jwtToken.Jti = jti;
                jwtToken.Issuer = issuer;
                jwtToken.Audience = audience;
                jwtToken.IssuedAt = currentDay;
                jwtToken.NotBefore = currentDay;
                jwtToken.Expires = currentDay.AddMinutes(expires);
                
                // Get Claims 
                var claims = await this.GetClaimsAsync(name, role, jwtToken);

                ClaimsIdentity subject = new ClaimsIdentity(claims);
                SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = jwtToken.Issuer,
                    Audience = jwtToken.Audience,
                    IssuedAt = jwtToken.IssuedAt,
                    NotBefore = jwtToken.NotBefore,
                    Expires = jwtToken.Expires,
                    Subject = subject,
                    SigningCredentials = signingCredentials
                };

                JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);

                jwtToken.Token = jwtTokenHandler.WriteToken(jwtSecurityToken);
                jwtToken.RefreshToken = await this.GenerateRefreshTokenAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return await Task.Run(() => jwtToken);
        }

        public ICollection<JwtToken> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<JwtToken>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ICollection<JwtToken> GetAllPaging(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<JwtToken>> GetAllPagingAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public JwtToken GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<JwtToken> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Claim>> GetClaimsAsync(string Name, string Role, JwtToken jwtToken)
        {
            if (string.IsNullOrEmpty(jwtToken.Jti))
            {
                jwtToken.Jti = Guid.NewGuid().ToString();
            }

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, Name),
                new Claim(ClaimTypes.Role, Role),
                new Claim(JwtRegisteredClaimNames.Jti, jwtToken.Jti),
                new Claim(JwtRegisteredClaimNames.Iss, jwtToken.Issuer),
                new Claim(JwtRegisteredClaimNames.Aud, jwtToken.Audience),
                new Claim(JwtRegisteredClaimNames.Iat, jwtToken.IssuedAt.ToString(), ClaimValueTypes.Integer),
                new Claim(JwtRegisteredClaimNames.Exp, jwtToken.Expires.ToString(), ClaimValueTypes.Integer)
            };

            return await Task.Run(() => claims);
        }

        public JwtToken Update(int id, JwtToken element)
        {
            throw new NotImplementedException();
        }

        public Task<JwtToken> UpdateAsync(int id, JwtToken element)
        {
            throw new NotImplementedException();
        }
    }
}
