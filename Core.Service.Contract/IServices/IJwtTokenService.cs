using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Contract.IServices
{
    public interface IJwtTokenService: IService<JwtToken>
    {
        Task<JwtToken> GenerateTokenAsync(string name, string role, string issuer, string audience, int expires, string key);
        Task<string> GenerateRefreshTokenAsync();
        Task<List<Claim>> GetClaimsAsync(string username, string role, JwtToken jwtToken);
    }
}
